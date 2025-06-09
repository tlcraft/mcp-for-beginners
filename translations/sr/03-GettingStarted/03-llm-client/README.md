<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:49:44+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sr"
}
-->
Сјајно, за наш следећи корак, хајде да наведемо могућности на серверу.

### -2 Наведи могућности сервера

Сада ћемо се повезати на сервер и затражити његове могућности:

### -3- Претвори могућности сервера у LLM алате

Следећи корак након навођења могућности сервера је да их претворимо у формат који LLM разуме. Када то урадимо, можемо те могућности да пружимо као алате нашем LLM-у.

Сјајно, сада смо спремни да обрадимо корисничке захтеве, па хајде да то урадимо следеће.

### -4- Обрада корисничког упита

У овом делу кода ћемо обрадити корисничке захтеве.

Сјајно, успели сте!

## Задатак

Узмите код из вежбе и проширите сервер са још неколико алата. Затим направите клијента са LLM-ом, као у вежби, и тестирајте га са различитим упитима како бисте били сигурни да се сви алати на серверу позивају динамички. Оваквим приступом изградње клијента крајњи корисник ће имати одлично корисничко искуство јер може користити упите у природном језику, уместо тачних команди клијента, и неће бити свестан позивања било ког MCP сервера.

## Решење

[Решење](/03-GettingStarted/03-llm-client/solution/README.md)

## Кључне поуке

- Додавање LLM-а вашем клијенту пружа бољи начин за интеракцију корисника са MCP серверима.
- Потребно је да одговор MCP сервера претворите у нешто што LLM може да разуме.

## Примери

- [Java калкулатор](../samples/java/calculator/README.md)
- [.Net калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript калкулатор](../samples/javascript/README.md)
- [TypeScript калкулатор](../samples/typescript/README.md)
- [Python калкулатор](../../../../03-GettingStarted/samples/python)

## Додатни ресурси

## Шта следи

- Следеће: [Коришћење сервера помоћу Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI servisa za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Izvorni dokument na njegovom izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.