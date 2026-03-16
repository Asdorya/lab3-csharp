# Учебное веб-приложение с минимальной функциональностью:
### Регистрация пользователя; авторизация; смена пароля; запись на вакцинацию.

Сделано с душой и моими слезам по мотивам:
* Предметной область - Центр вакцинации

Представляет собой веб-приложение где новый пользователь может зарегестрироваться, войти в личный кабинет, сменить пароль по желанию и записаться на желаемую вакцинацию.

## Сборка проекта
docker pull sonarqube
docker run -d --name sonarqube -p 9000:9000 sonarqube
*http://localhost:9000

dotnet sonarscanner begin /k:"Sign_up_Vaccinations" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="squ_980a9a65be29462cb377b3812d330f7cf856625b"
dotnet build
dotnet sonarscanner end /d:sonar.token="squ_980a9a65be29462cb377b3812d330f7cf856625b"

## Команды git:
1. cd Desktop
2. git clone https://github.com/Asdorya/lab3-csharp.git
3. сd lab3-csharp
4. git pull - обновление данных ветки с репозитория
5. git add *
6. git commit -a -m "Комментарий"
7. git push origin --all


*https://olgakraven.github.io/DKIP.PM.05.MDK.01-PIDIS.02/3.html#11
