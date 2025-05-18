<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:06:09+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

Рекомендуется установить `uv`, но это не обязательно, смотрите [инструкции](https://docs.astral.sh/uv/#highlights)

## -1- Установите зависимости

```bash
npm install
```

## -3- Запустите сервер

```bash
npm run build
```

## -4- Запустите клиент

```sh
npm run client
```

Вы должны увидеть результат, похожий на:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, пожалуйста, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на родном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникающие в результате использования этого перевода.