<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T01:59:50+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

Здесь показано, как запустить классический HTTP streaming сервер и клиент, а также MCP streaming сервер и клиент на Python.

### Обзор

- Вы настроите MCP сервер, который будет отправлять клиенту уведомления о ходе обработки элементов.
- Клиент будет отображать каждое уведомление в реальном времени.
- В этом руководстве рассмотрены требования, установка, запуск и устранение неполадок.

### Требования

- Python 3.9 или новее
- Пакет `mcp` для Python (установить с помощью `pip install mcp`)

### Установка и настройка

1. Клонируйте репозиторий или скачайте файлы решения.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Создайте и активируйте виртуальное окружение (рекомендуется):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Установите необходимые зависимости:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Файлы

- **Сервер:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Клиент:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Запуск классического HTTP streaming сервера

1. Перейдите в каталог с решением:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Запустите классический HTTP streaming сервер:

   ```pwsh
   python server.py
   ```

3. Сервер запустится и выведет:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Запуск классического HTTP streaming клиента

1. Откройте новый терминал (активируйте то же виртуальное окружение и перейдите в каталог):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Вы увидите, как последовательно выводятся передаваемые сообщения:

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

### Запуск MCP streaming сервера

1. Перейдите в каталог с решением:  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```  
2. Запустите MCP сервер с транспортом streamable-http:  
   ```pwsh
   python server.py mcp
   ```  
3. Сервер запустится и выведет:  
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Запуск MCP streaming клиента

1. Откройте новый терминал (активируйте то же виртуальное окружение и перейдите в каталог):  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```  
2. Вы увидите уведомления в реальном времени по мере обработки каждого элемента сервером:  
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

### Основные шаги реализации

1. **Создайте MCP сервер с помощью FastMCP.**  
2. **Определите инструмент, который обрабатывает список и отправляет уведомления с помощью `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` для неблокирующих операций.**  
- Всегда обрабатывайте исключения на стороне сервера и клиента для надежности.  
- Тестируйте с несколькими клиентами, чтобы увидеть обновления в реальном времени.  
- Если возникают ошибки, проверьте версию Python и убедитесь, что все зависимости установлены.

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, просим учитывать, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется использовать профессиональный перевод, выполненный человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.