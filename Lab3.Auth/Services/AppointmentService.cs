using System.Collections.Concurrent;

namespace Lab3.Auth.Services;

public record Appointment(string Username, DateOnly Date, string Vaccine, string? Note);

public record AppointmentResult(bool Success, string Message, Appointment? Appointment = null);

public interface IAppointmentService
{
    AppointmentResult Create(string username, DateOnly date, string vaccine, string? note);
    IReadOnlyList<Appointment> GetByUser(string username);
    IReadOnlyList<Appointment> GetAll();
    void Clear(); // для тестов/демо
}

public class AppointmentService : IAppointmentService
{
    private readonly ConcurrentBag<Appointment> _appointments = new();

    public AppointmentResult Create(string username, DateOnly date, string vaccine, string? note)
    {
        if (string.IsNullOrWhiteSpace(username))
            return new AppointmentResult(false, "Логин обязателен");

        if (date < DateOnly.FromDateTime(DateTime.Today))
            return new AppointmentResult(false, "Нельзя записаться в прошлое");

        if (string.IsNullOrWhiteSpace(vaccine))
            return new AppointmentResult(false, "Выберите вакцину");

        var appt = new Appointment(username, date, vaccine.Trim(), string.IsNullOrWhiteSpace(note) ? null : note.Trim());
        _appointments.Add(appt);
        return new AppointmentResult(true, "Запись создана", appt);
    }

    public IReadOnlyList<Appointment> GetByUser(string username) =>
        _appointments.Where(a => string.Equals(a.Username, username, StringComparison.OrdinalIgnoreCase)).ToList();

    public IReadOnlyList<Appointment> GetAll() => _appointments.ToList();

    public void Clear()
    {
        while (_appointments.TryTake(out _)) { }
    }
}

