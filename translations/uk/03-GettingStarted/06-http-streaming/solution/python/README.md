<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:23:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

Ось як запустити класичний HTTP стрімінговий сервер і клієнт, а також MCP стрімінговий сервер і клієнт за допомогою Python.

### Огляд

- Ви налаштуєте MCP сервер, який надсилатиме клієнту сповіщення про прогрес під час обробки елементів.
- Клієнт відображатиме кожне сповіщення в реальному часі.
- Цей посібник охоплює вимоги, налаштування, запуск і усунення неполадок.

### Вимоги

- Python 3.9 або новіша версія
- Пакет `mcp` для Python (встановити за допомогою `pip install mcp`)

### Встановлення та налаштування

1. Клонуйте репозиторій або завантажте файли рішення.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Створіть і активуйте віртуальне середовище (рекомендується):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Встановіть необхідні залежності:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Файли

- **Сервер:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Клієнт:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Запуск класичного HTTP стрімінгового сервера

1. Перейдіть у каталог з рішенням:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Запустіть класичний HTTP стрімінговий сервер:

   ```pwsh
   python server.py
   ```

3. Сервер запуститься і відобразить:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Запуск класичного HTTP стрімінгового клієнта

1. Відкрийте новий термінал (активуйте те саме віртуальне середовище і перейдіть у каталог):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Ви побачите послідовно виведені стрімінгові повідомлення:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Запуск MCP стрімінгового сервера

1. Перейдіть у каталог з рішенням:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Запустіть MCP сервер з транспортом streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Сервер запуститься і відобразить:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Запуск MCP стрімінгового клієнта

1. Відкрийте новий термінал (активуйте те саме віртуальне середовище і перейдіть у каталог):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Ви побачите сповіщення, які виводяться в реальному часі під час обробки кожного елемента сервером:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Основні кроки реалізації

1. **Створіть MCP сервер за допомогою FastMCP.**
2. **Визначте інструмент, який обробляє список і надсилає сповіщення через `ctx.info()` або `ctx.log()`.**
3. **Запустіть сервер з параметром `transport="streamable-http"`.**
4. **Реалізуйте клієнта з обробником повідомлень, який відображатиме сповіщення по мірі їх надходження.**

### Огляд коду
- Сервер використовує асинхронні функції та контекст MCP для надсилання оновлень прогресу.
- Клієнт реалізує асинхронний обробник повідомлень для виведення сповіщень і кінцевого результату.

### Поради та усунення неполадок

- Використовуйте `async/await` для неблокуючих операцій.
- Завжди обробляйте виключення як на сервері, так і на клієнті для надійності.
- Тестуйте з кількома клієнтами, щоб побачити оновлення в реальному часі.
- Якщо виникають помилки, перевірте версію Python і переконайтеся, що всі залежності встановлені.

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.