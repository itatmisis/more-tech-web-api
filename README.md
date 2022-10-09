# More Tech 4.0 WEB
## CryptoPunks
### Платформа с элементами геймификации для вовлечения сотрудников

#### FAQ: Как запустить
0. Необходим установленный docker-compose
1. Для работы с крипто api необходимо В `.env` проставить ключи сервисного кошелька и hostname
```
...
# CRYPTO CREDENTIALS
CW_PUBLIC_KEY=
CW_PRIVATE_KEY=
CW_HOST_NAME=
```
2. В папке репозитория прописать `docker-compose up -d`
> http://localhost:8000/ - front </br>
> http://localhost:1001/swagger - api swagger docs
#### Состав проекта
Папка `api` - backend проект сервиса </br>
Папка `web` - релизный билд flutter front-end проекта </br>
Папка `more_tech` - исходный код flutter проекта (разрабатывался в отдельном [репозитории](https://github.com/itatmisis/more-tech-web-ui), перенесен сюда для удобства запуска)

#### Стек
*Backend* - ASP.NET Core + PostgresSQL </br>
*Frontend* - Flutter Web



