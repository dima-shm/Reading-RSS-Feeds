# Reading-RSS-Feeds — «Чтение RSS ленты»

Задача: разработать приложения, выполняющие чтение, разбор, отображение новостей из RSS-лент.

## 1. Используемые технологии
- С#
- MVC
- Entity Framework, code first
    - либо LINQ to SQL + скрипт по развертыванию БД

## 2. База данных
Создать БД MSSQL в нормальной форме для хранения информации о новостях из RSS лент:
- Заголовок новости
- URL новости
- Описание новости
- Дата публикации новости
- RSS-источник
    - URL
    - Название
    - Описание
    - Язык
    
RSS источники:
- [http://habrahabr.ru/rss/](http://habrahabr.ru/rss/)  – Хабрахабр
- [http://www.interfax.by/news/feed](http://www.interfax.by/news/feed) – Интерфакс
- [https://www.belstu.by/rss](https://www.belstu.by/rss) – БГТУ

## 3. Консольное приложение
Разработать консольное приложение, выполняющее действия:
- Прочитать новости из всех RSS-источников
- Сохранить в БД только свежие новости (отсутствующие в базе данных). Уникальным
идентификатором новости является заголовок и дата публикации.
- Вывести на консоль информацию по каждому источнику:
    - Прочитано новостей
    - Сохранено новостей
    
## 4. Web-приложение (сайт)
Разработать Web-страницу для отображения ленты новостей.
Внешний вид страницы:
![screenshot of sample](https://github.com/dima-shm/Reading-RSS-Feeds/blob/master/SamplePage.jpg)

## Требования:
- Разработать Web-страницу в 2-х вариантах:
    - Получение данных POST-запросом
    - Получение данных AJAX-запросом
- Реализовать пагинацию по 10 записей на странице

## Результат:
![screenshot of sample](https://github.com/dima-shm/Reading-RSS-Feeds/blob/master/Preview2.jpg)

![screenshot of sample](https://github.com/dima-shm/Reading-RSS-Feeds/blob/master/Preview1.jpg)

## Authors

* **Shumanski Dima** - [dima-shm](https://github.com/dima-shm)
