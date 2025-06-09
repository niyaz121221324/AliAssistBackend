# AliAssistApp

AliAssistApp — это внутренний сервис, разработанный для агрегации и синхронизации данных с различных маркетплейсов, таких как Ozon, AliExpress, Wildberries и другие. Он обеспечивает централизованное взаимодействие с внешними API и предоставляет актуальную информацию о товарах, ценах и наличии.

## 🧩 Основные функции

- 🔄 Интеграция с внешними API (Ozon, AliExpress, Wildberries и др.)
- 📦 Получение и актуализация информации о товарах
- 💲 Сбор цен и отслеживание изменений
- 📊 Мониторинг наличия и состояния товаров
- 🔐 Авторизация на основе JWT токенов

## 🛠️ Технологии

- **.NET 8 / ASP.NET Core**
- **PostgreSQL**
- **Docker / Docker Compose**
- **JWT (JSON Web Tokens)**
- **HttpClient / Background Services**

## Скрипт для запуска бд
```sql
-- Создание таблицы пользователей
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Создание таблицы товаров
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price VARCHAR(50) NOT NULL,
    currency VARCHAR(10) NOT NULL,
    source VARCHAR(100) NOT NULL,
    link TEXT NOT NULL
);

-- Создание таблицы корзины
CREATE TABLE cart (
    user_id INTEGER NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    product_id INTEGER NOT NULL REFERENCES products(id) ON DELETE CASCADE,
    added_at TIMESTAMP DEFAULT NOW(),

    PRIMARY KEY (user_id, product_id)
);
```

## 🚀 Быстрый старт

### 1. Клонируйте репозиторий

```bash
git clone https://github.com/your-org/aliassistapp.git](https://github.com/niyaz121221324/AliAssistBackend.git
cd aliassistapp
