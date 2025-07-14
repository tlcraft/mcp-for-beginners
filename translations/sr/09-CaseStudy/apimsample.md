<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:37:49+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "sr"
}
-->
# Студија случаја: Излагање REST API у API Management као MCP сервер

Azure API Management је услуга која пружа Gateway изнад ваших API крајњих тачака. Начин рада је такав да Azure API Management функционише као прокси испред ваших API-ја и може одлучити шта ће радити са долазним захтевима.

Коришћењем ове услуге добијате читав низ функција као што су:

- **Безбедност**, можете користити све од API кључева, JWT-а до managed identity.
- **Ограничење броја позива (rate limiting)**, одлична функција која вам омогућава да одредите колико позива може проћи у одређеном временском периоду. Ово помаже да сви корисници имају одлично искуство и да ваша услуга не буде преоптерећена захтевима.
- **Скалирање и балансирање оптерећења**. Можете подесити више крајњих тачака за расподелу оптерећења и одлучити како ће се вршити балансирање.
- **AI функције као што су семантичко кеширање**, ограничење токена и праћење токена и још много тога. Ове функције побољшавају одзивност и помажу вам да пратите потрошњу токена. [Прочитајте више овде](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Зашто MCP + Azure API Management?

Model Context Protocol брзо постаје стандард за агентске AI апликације и начин да се алати и подаци изложе на доследан начин. Azure API Management је природан избор када треба да "управљате" API-јима. MCP сервери често интегришу друге API-је како би решавали захтеве ка неком алату, на пример. Због тога комбинација Azure API Management и MCP има пуно смисла.

## Преглед

У овом конкретном случају користи ћемо да научимо како да изложимо API крајње тачке као MCP сервер. На овај начин лако можемо учинити ове крајње тачке делом агентске апликације, уз коришћење функција Azure API Management.

## Кључне функције

- Изаберете методе крајњих тачака које желите да изложите као алате.
- Додатне функције које добијате зависе од тога шта конфигуришете у одељку политика за ваш API. Овде ћемо показати како да додате ограничење броја позива.

## Претходни корак: увоз API-ја

Ако већ имате API у Azure API Management, одлично, можете прескочити овај корак. У супротном, погледајте овај линк, [увоз API-ја у Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Излагање API као MCP сервер

Да бисмо изложили API крајње тачке, пратимо следеће кораке:

1. Идите на Azure портал на адресу <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Идите на вашу инстанцу API Management-а.

1. У левом менију изаберите APIs > MCP Servers > + Create new MCP Server.

1. У API-ју изаберите REST API који желите да изложите као MCP сервер.

1. Изаберите једну или више API операција које желите да изложите као алате. Можете изабрати све операције или само одређене.

    ![Изаберите методе за излагање](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Изаберите **Create**.

1. Идите на мени опцију **APIs** и **MCP Servers**, требало би да видите следеће:

    ![Погледајте MCP сервер у главном прозору](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP сервер је креиран и API операције су изложене као алати. MCP сервер је наведен у панелу MCP Servers. Колона URL приказује крајњу тачку MCP сервера коју можете позвати за тестирање или у клијент апликацији.

## Опционо: Конфигурисање политика

Azure API Management има основни концепт политика где подешавате различита правила за ваше крајње тачке, као што су ограничење броја позива или семантичко кеширање. Ове политике се пишу у XML формату.

Ево како можете подесити политику за ограничење броја позива на вашем MCP серверу:

1. У порталу, под APIs, изаберите **MCP Servers**.

1. Изаберите MCP сервер који сте креирали.

1. У левом менију, под MCP, изаберите **Policies**.

1. У едитору политика додајте или измените политике које желите да примените на алате MCP сервера. Политике су дефинисане у XML формату. На пример, можете додати политику која ограничава позиве алатима MCP сервера (у овом примеру, 5 позива на 30 секунди по IP адреси клијента). Ево XML који ће извршити ограничење:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Ево слике едитора политика:

    ![Едитор политика](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Испробајте

Хајде да проверимо да ли наш MCP сервер ради како треба.

За ово ћемо користити Visual Studio Code и GitHub Copilot у Agent режиму. Додаћемо MCP сервер у *mcp.json* датотеку. На овај начин, Visual Studio Code ће деловати као клијент са агентским могућностима, а крајњи корисници ће моћи да уносе упите и комуницирају са сервером.

Погледајмо како да додамо MCP сервер у Visual Studio Code:

1. Користите команду MCP: **Add Server из Command Palette-а**.

1. Када вас пита, изаберите тип сервера: **HTTP (HTTP или Server Sent Events)**.

1. Унесите URL MCP сервера у API Management-у. Пример: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (за SSE крајњу тачку) или **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (за MCP крајњу тачку), обратите пажњу на разлику у транспорту која је `/sse` или `/mcp`.

1. Унесите ID сервера по вашем избору. Ова вредност није критична, али ће вам помоћи да се сетите о којој инстанци сервера је реч.

1. Изаберите да ли желите да сачувате конфигурацију у подешавањима радног простора или корисничким подешавањима.

  - **Workspace settings** - Конфигурација сервера се чува у .vscode/mcp.json датотеци која је доступна само у тренутном радном простору.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    или ако изаберете streaming HTTP као транспорт, биће мало другачије:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Конфигурација сервера се додаје у глобалну *settings.json* датотеку и доступна је у свим радним просторима. Конфигурација изгледа отприлике овако:

    ![Корисничка подешавања](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Такође морате додати конфигурацију, заглавље које осигурава исправну аутентификацију према Azure API Management-у. Користи се заглавље под називом **Ocp-Apim-Subscription-Key**.

    - Ево како га можете додати у подешавања:

    ![Додавање заглавља за аутентификацију](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ово ће изазвати да се појави упит за унос вредности API кључа коју можете пронаћи у Azure порталу за вашу Azure API Management инстанцу.

   - Да бисте га додали у *mcp.json*, можете га додати овако:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Користите Agent режим

Сада смо све подесили у подешавањима или у *.vscode/mcp.json*. Хајде да испробамо.

Требало би да видите икону Tools као ову, где су наведени изложени алати са вашег сервера:

![Алатке са сервера](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Кликните на икону алата и требало би да видите листу алата као ову:

    ![Алатке](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Унесите упит у ћаскање да позовете алат. На пример, ако сте изабрали алат за добијање информација о поруџбини, можете питати агента о поруџбини. Ево примера упита:

    ```text
    get information from order 2
    ```

    Сада ће вам бити приказана икона алата која тражи да наставите са позивом алата. Изаберите да наставите са извршавањем алата, требало би да видите излаз као на слици:

    ![Резултат упита](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **оно што видите горе зависи од тога које алате сте подесили, али идеја је да добијете текстуални одговор као горе**

## Референце

Ево како можете сазнати више:

- [Туторијал о Azure API Management и MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python пример: Безбедни удаљени MCP сервери користећи Azure API Management (експериментално)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP client authorization lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Користите Azure API Management екстензију за VS Code за увоз и управљање API-јима](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Региструјте и откријте удаљене MCP сервере у Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Одличан репозиторијум који приказује многе AI могућности са Azure API Management-ом
- [AI Gateway радионице](https://azure-samples.github.io/AI-Gateway/) Садржи радионице користећи Azure портал, што је одличан начин да почнете са проценом AI могућности.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.