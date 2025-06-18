<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:53:43+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "sr"
}
-->
# Пример

Претходни пример показује како користити локални .NET пројекат са `stdio` типом. И како покренути сервер локално у контејнеру. Ово је добро решење у многим ситуацијама. Међутим, може бити корисно да сервер ради удаљено, као у облачном окружењу. Ту долази до изражаја `http` тип.

Када погледате решење у `04-PracticalImplementation` фасцикли, може изгледати знатно сложеније него претходно. Али у ствари, није тако. Ако пажљиво погледате пројекат `src/Calculator`, видећете да је углавном исти код као у претходном примеру. Једина разлика је што користимо другу библиотеку `ModelContextProtocol.AspNetCore` за руковање HTTP захтевима. И мењамо методу `IsPrime` да буде приватна, само да покажемо да у коду можете имати приватне методе. Остатак кода је исти као раније.

Остали пројекти су из [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Имање .NET Aspire у решењу побољшава искуство програмера током развоја и тестирања и помаже у посматрању. Није обавезно за покретање сервера, али је добра пракса да га имате у решењу.

## Покрени сервер локално

1. У VS Code-у (са C# DevKit екстензијом), идите до `04-PracticalImplementation/samples/csharp` директоријума.
1. Извршите следећу команду да бисте покренули сервер:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Када веб прегледач отвори .NET Aspire контролну таблу, запамтите `http` URL. Требало би да буде нешто као `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.sr.png)

## Тестирање Streamable HTTP помоћу MCP Inspector-а

Ако имате Node.js верзију 22.7.5 или новију, можете користити MCP Inspector за тестирање вашег сервера.

Покрените сервер и у терминалу покрените следећу команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.sr.png)

- Изаберите `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Требало би да буде `http` (не `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` сервер који је раније креиран да изгледа овако:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Извршите неке тестове:

- Затражите "3 простa броја после 6780". Обратите пажњу како Copilot користи нове алате `NextFivePrimeNumbers` и враћа само прва 3 простa броја.
- Затражите "7 простих бројева после 111", да видите шта ће се десити.
- Затражите "Јован има 24 леденца и жели да их подели на 3 детета. Колико леденца има сваки дете?", да видите резултат.

## Деплоy сервера на Azure

Хајде да деплоy-ујемо сервер на Azure да би више људи могло да га користи.

Из терминала идите у фасциклу `04-PracticalImplementation/samples/csharp` и покрените следећу команду:

```bash
azd up
```

Када се деплоy заврши, требало би да видите поруку оваквог типа:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.sr.png)

Узмите URL и користите га у MCP Inspector-у и у GitHub Copilot Chat-у.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## Шта следи?

Испробавамо различите типове транспорта и алате за тестирање. Такође деплоy-ујемо ваш MCP сервер на Azure. Али шта ако наш сервер треба приступ приватним ресурсима? На пример, бази података или приватном API-ју? У следећем поглављу видећемо како можемо побољшати безбедност нашег сервера.

**Одрицање одговорности**:  
Овај документ је преведен коришћењем АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод који обавља човек. Не одговарамо за било каква неспоразума или погрешне тумачења настала коришћењем овог превода.