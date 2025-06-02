<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:08:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bg"
}
-->
### -2- Създаване на проект

Сега, когато сте инсталирали SDK-то, нека създадем проект: 

### -3- Създаване на файлове за проекта

### -4- Създаване на код за сървъра

### -5- Добавяне на инструмент и ресурс

Добавете инструмент и ресурс, като включите следния код:

### -6 Финален код

Нека добавим последния необходим код, за да може сървърът да стартира:

### -7- Тествайте сървъра

Стартирайте сървъра с командата по-долу:

### -8- Стартиране чрез инспектора

Inspector е чудесен инструмент, който може да стартира вашия сървър и ви позволява да взаимодействате с него, за да тествате дали работи. Нека го стартираме:

> [!NOTE]
> полето "command" може да изглежда различно, тъй като съдържа командата за стартиране на сървър с вашия конкретен runtime/

Трябва да видите следния потребителски интерфейс:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bg.png)

1. Свържете се със сървъра, като изберете бутона Connect  
   След като се свържете със сървъра, трябва да видите следното:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bg.png)

2. Изберете "Tools" и "listTools", трябва да се появи "Add", изберете "Add" и попълнете стойностите на параметрите.

   Трябва да видите следния отговор, т.е. резултат от инструмента "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bg.png)

Поздравления, успяхте да създадете и стартирате първия си сървър!

### Официални SDK-та

MCP предоставя официални SDK-та за няколко езика:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Поддържан в сътрудничество с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Поддържан в сътрудничество с Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Официалната TypeScript имплементация
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Официалната Python имплементация
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официалната Kotlin имплементация
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддържан в сътрудничество с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официалната Rust имплементация

## Основни изводи

- Настройването на MCP среда за разработка е лесно с езиково-специфични SDK-та
- Създаването на MCP сървъри включва създаване и регистриране на инструменти с ясни схеми
- Тестването и отстраняването на грешки са от съществено значение за надеждни MCP реализации

## Примери

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Задача

Създайте прост MCP сървър с инструмент по ваш избор:
1. Имплементирайте инструмента на предпочитания от вас език (.NET, Java, Python или JavaScript).
2. Определете входни параметри и стойности за връщане.
3. Стартирайте инспектора, за да се уверите, че сървърът работи както трябва.
4. Тествайте имплементацията с различни входни данни.

## Решение

[Решение](./solution/README.md)

## Допълнителни ресурси

- [MCP GitHub хранилище](https://github.com/microsoft/mcp-for-beginners)

## Какво следва

Следва: [Започване с MCP клиенти](/03-GettingStarted/02-client/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, възникнали в резултат на използването на този превод.