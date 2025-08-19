<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2228721599c0c8673de83496b4d7d7a9",
<<<<<<< HEAD
  "translation_date": "2025-08-18T21:27:17+00:00",
=======
  "translation_date": "2025-08-18T16:44:08+00:00",
>>>>>>> origin/main
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "sr"
}
-->
<<<<<<< HEAD
# Студија случаја: Излагање REST API у API Management као MCP сервер

Azure API Management је услуга која обезбеђује Gateway изнад ваших API Endpoint-а. Како функционише је да Azure API Management делује као прокси испред ваших API-ја и може да одлучи шта да ради са долазним захтевима.

Користећи ову услугу, добијате низ функција као што су:

- **Безбедност**, можете користити све од API кључева, JWT до управљаног идентитета.
- **Ограничење брзине**, одлична функција која вам омогућава да одредите колико позива пролази у одређеном временском периоду. Ово помаже да сви корисници имају добро искуство и да ваша услуга не буде преоптерећена захтевима.
- **Скалабилност и баланс оптерећења**. Можете поставити више Endpoint-а за расподелу оптерећења и такође одредити како да "балансирате оптерећење".
- **AI функције као што су семантичко кеширање**, ограничење токена, праћење токена и још много тога. Ово су одличне функције које побољшавају одзивност и помажу вам да будете у току са потрошњом токена. [Прочитајте више овде](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Зашто MCP + Azure API Management?

Model Context Protocol брзо постаје стандард за апликације са агентском AI и начин излагања алата и података на конзистентан начин. Azure API Management је природан избор када треба да "управљате" API-јима. MCP сервери често интегришу са другим API-јима ради решавања захтева за алат, на пример. Због тога комбинација Azure API Management и MCP има пуно смисла.

## Преглед

У овом конкретном случају употребе научићемо како да изложимо API Endpoint-е као MCP сервер. На овај начин, лако можемо учинити ове Endpoint-е делом апликације са агентским AI, уз коришћење функција Azure API Management.

## Кључне функције

- Бирате методе Endpoint-а које желите да изложите као алате.
- Додатне функције које добијате зависе од тога шта конфигуришете у секцији политика за ваш API. Овде ћемо показати како можете додати ограничење брзине.

## Претходни корак: увоз API-ја

Ако већ имате API у Azure API Management, одлично, онда можете прескочити овај корак. Ако не, погледајте овај линк, [увоз API-ја у Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Излагање API-ја као MCP сервер

Да бисмо изложили API Endpoint-е, следите ове кораке:

1. Идите на Azure Portal и следећу адресу <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Отворите вашу инстанцу API Management.

1. У левом менију, изаберите APIs > MCP Servers > + Create new MCP Server.
=======
# Студија случаја: Излагање REST API-ја у API Management као MCP сервер

Azure API Management је услуга која пружа Gateway изнад ваших API крајњих тачака. Како функционише? Azure API Management делује као прокси испред ваших API-ја и може одлучивати шта да ради са долазним захтевима.

Коришћењем ове услуге добијате низ функција као што су:

- **Безбедност**, можете користити све од API кључева, JWT до управљаног идентитета.
- **Ограничење брзине**, одлична функција која омогућава одређивање колико позива пролази у одређеном временском периоду. Ово осигурава да сви корисници имају добро искуство и да ваша услуга није преоптерећена захтевима.
- **Скалирање и балансирање оптерећења**. Можете подесити више крајњих тачака за балансирање оптерећења и такође одлучити како да "балансирате оптерећење".
- **AI функције као што су семантичко кеширање**, ограничење токена, праћење токена и још много тога. Ово су одличне функције које побољшавају одзивност и помажу вам да пратите потрошњу токена. [Прочитајте више овде](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Зашто MCP + Azure API Management?

Model Context Protocol брзо постаје стандард за агентске AI апликације и начин излагања алата и података на конзистентан начин. Azure API Management је природан избор када треба да "управљате" API-јима. MCP сервери често интегришу са другим API-јима како би решили захтеве за алатима, на пример. Због тога комбинација Azure API Management и MCP има пуно смисла.

## Преглед

У овом конкретном случају ћемо научити како да изложимо API крајње тачке као MCP сервер. На овај начин, лако можемо учинити ове крајње тачке делом агентске апликације, уз коришћење функција Azure API Management.

## Кључне карактеристике

- Бирате методе крајњих тачака које желите да изложите као алате.
- Додатне функције које добијате зависе од тога шта конфигуришете у одељку за полисе вашег API-ја. Овде ћемо показати како можете додати ограничење брзине.

## Претходни корак: увоз API-ја

Ако већ имате API у Azure API Management, одлично, можете прескочити овај корак. Ако не, погледајте овај линк, [увоз API-ја у Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Излагање API-ја као MCP сервера

Да бисмо изложили API крајње тачке, следимо ове кораке:

1. Идите на Azure Portal и следећу адресу <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Отворите вашу API Management инстанцу.

1. У левом менију изаберите APIs > MCP Servers > + Create new MCP Server.
>>>>>>> origin/main

1. У API, изаберите REST API који желите да изложите као MCP сервер.

1. Изаберите једну или више API операција које желите да изложите као алате. Можете изабрати све операције или само одређене.

    ![Изаберите методе за излагање](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Изаберите **Create**.

1. Идите на опцију менија **APIs** и **MCP Servers**, требало би да видите следеће:

    ![Погледајте MCP сервер у главном панелу](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

<<<<<<< HEAD
    MCP сервер је креиран и API операције су изложене као алати. MCP сервер је приказан у панелу MCP Servers. Колона URL показује Endpoint MCP сервера који можете позвати ради тестирања или унутар клијентске апликације.

## Опционо: Конфигуришите политике

Azure API Management има основни концепт политика где постављате различита правила за ваше Endpoint-е, као што су ограничење брзине или семантичко кеширање. Ове политике се пишу у XML формату.

Ево како можете поставити политику за ограничење брзине вашег MCP сервера:
=======
    MCP сервер је креиран и API операције су изложене као алати. MCP сервер је наведен у панелу MCP Servers. Колона URL приказује крајњу тачку MCP сервера коју можете позвати за тестирање или унутар клијентске апликације.

## Опционо: Конфигурисање полиса

Azure API Management има основни концепт полиса где постављате различита правила за ваше крајње тачке, као што су ограничење брзине или семантичко кеширање. Ове полисе се пишу у XML формату.

Ево како можете подесити полису за ограничење брзине вашег MCP сервера:
>>>>>>> origin/main

1. У порталу, под APIs, изаберите **MCP Servers**.

1. Изаберите MCP сервер који сте креирали.

1. У левом менију, под MCP, изаберите **Policies**.

<<<<<<< HEAD
1. У уређивачу политика, додајте или измените политике које желите да примените на алате MCP сервера. Политике су дефинисане у XML формату. На пример, можете додати политику за ограничење позива MCP сервера (у овом примеру, 5 позива у 30 секунди по IP адреси клијента). Ево XML-а који ће узроковати ограничење брзине:
=======
1. У уређивачу полиса, додајте или измените полисе које желите да примените на алате MCP сервера. Полисе су дефинисане у XML формату. На пример, можете додати полису за ограничавање позива на алате MCP сервера (у овом примеру, 5 позива у 30 секунди по IP адреси клијента). Ево XML-а који ће узроковати ограничење брзине:
>>>>>>> origin/main

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

<<<<<<< HEAD
    Ево слике уређивача политика:

    ![Уређивач политика](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
=======
    Ево слике уређивача полиса:

    ![Уређивач полиса](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
>>>>>>> origin/main

## Испробајте

Хајде да се уверимо да MCP сервер ради како је предвиђено.

<<<<<<< HEAD
За ово, користићемо Visual Studio Code и GitHub Copilot у његовом Agent режиму. Додаћемо MCP сервер у *mcp.json* датотеку. На овај начин, Visual Studio Code ће деловати као клијент са агентским способностима, а крајњи корисници ће моћи да унесу упит и интерагују са сервером.
=======
За ово ћемо користити Visual Studio Code и GitHub Copilot у његовом Agent режиму. Додаћемо MCP сервер у *mcp.json* датотеку. На овај начин, Visual Studio Code ће деловати као клијент са агентским могућностима, а крајњи корисници ће моћи да унесу упит и комуницирају са сервером.
>>>>>>> origin/main

Ево како да додате MCP сервер у Visual Studio Code:

1. Користите MCP: **Add Server команду из Command Palette**.

<<<<<<< HEAD
1. Када се затражи, изаберите тип сервера: **HTTP (HTTP или Server Sent Events)**.

1. Унесите URL MCP сервера у API Management. Пример: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (за SSE Endpoint) или **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (за MCP Endpoint), обратите пажњу на разлику између транспорта `/sse` или `/mcp`.

1. Унесите ID сервера по вашем избору. Ова вредност није важна, али ће вам помоћи да запамтите шта је ова инстанца сервера.

1. Изаберите да ли желите да сачувате конфигурацију у подешавањима радног окружења или корисничким подешавањима.

  - **Подешавања радног окружења** - Конфигурација сервера се чува у .vscode/mcp.json датотеци доступној само у тренутном радном окружењу.
=======
1. Када се од вас затражи, изаберите тип сервера: **HTTP (HTTP или Server Sent Events)**.

1. Унесите URL MCP сервера у API Management. Пример: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (за SSE крајњу тачку) или **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (за MCP крајњу тачку), обратите пажњу на разлику између транспорта `/sse` или `/mcp`.

1. Унесите ID сервера по вашем избору. Ова вредност није важна, али ће вам помоћи да запамтите шта је ова инстанца сервера.

1. Изаберите да ли желите да сачувате конфигурацију у подешавањима радног простора или корисничким подешавањима.

  - **Подешавања радног простора** - Конфигурација сервера се чува у .vscode/mcp.json датотеци доступној само у тренутном радном простору.
>>>>>>> origin/main

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    или ако изаберете стриминг HTTP као транспорт, изгледаће мало другачије:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

<<<<<<< HEAD
  - **Корисничка подешавања** - Конфигурација сервера се додаје у вашу глобалну *settings.json* датотеку и доступна је у свим радним окружењима. Конфигурација изгледа слично следећем:

    ![Корисничка подешавања](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Такође треба да додате конфигурацију, хедер за аутентификацију према Azure API Management. Користи се хедер под називом **Ocp-Apim-Subscription-Key**.

    - Ево како можете додати хедер у подешавања:

    ![Додавање хедера за аутентификацију](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ово ће узроковати да се прикаже упит за вредност API кључа коју можете пронаћи у Azure Portal за вашу инстанцу Azure API Management.
=======
  - **Корисничка подешавања** - Конфигурација сервера се додаје у ваш глобални *settings.json* фајл и доступна је у свим радним просторима. Конфигурација изгледа слично следећем:

    ![Корисничка подешавања](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Такође треба да додате конфигурацију, хедер како бисте осигурали исправну аутентификацију према Azure API Management. Користи се хедер под називом **Ocp-Apim-Subscription-Key**.

    - Ево како можете додати хедер у подешавања:

    ![Додавање хедера за аутентификацију](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ово ће узроковати да се прикаже упит за вредност API кључа коју можете пронаћи у Azure Portal за вашу Azure API Management инстанцу.
>>>>>>> origin/main

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

<<<<<<< HEAD
### Користите Agent режим

Сада смо све поставили у подешавањима или у *.vscode/mcp.json*. Хајде да испробамо.

Требало би да постоји икона за алате као што је приказано, где су наведени изложени алати са вашег сервера:
=======
### Коришћење Agent режима

Сада смо све подесили у подешавањима или у *.vscode/mcp.json*. Хајде да испробамо.

Требало би да постоји икона алата где су наведени алати изложени са вашег сервера:
>>>>>>> origin/main

![Алати са сервера](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Кликните на икону алата и требало би да видите листу алата као што је приказано:

    ![Алати](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

<<<<<<< HEAD
1. Унесите упит у чет да бисте позвали алат. На пример, ако сте изабрали алат за добијање информација о поруџбини, можете питати агента о поруџбини. Ево примера упита:
=======
1. Унесите упит у чет да бисте позвали алат. На пример, ако сте изабрали алат за добијање информација о наруџбини, можете питати агента о наруџбини. Ево примера упита:
>>>>>>> origin/main

    ```text
    get information from order 2
    ```

<<<<<<< HEAD
    Сада ће вам бити приказана икона алата која вас пита да наставите са позивом алата. Изаберите да наставите са извршавањем алата, требало би да видите излаз као што је приказано:

    ![Резултат упита](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **оно што видите зависи од тога које сте алате поставили, али идеја је да добијете текстуални одговор као горе**
=======
    Сада ће вам бити приказана икона алата која вас пита да наставите са позивањем алата. Изаберите да наставите са извршавањем алата, требало би да видите излаз као што је приказано:

    ![Резултат упита](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **оно што видите зависи од тога које сте алате подесили, али идеја је да добијете текстуални одговор као горе**
>>>>>>> origin/main

## Референце

Ево како можете сазнати више:

- [Туторијал о Azure API Management и MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
<<<<<<< HEAD
- [Python пример: Сигурно удаљено MCP сервере користећи Azure API Management (експериментално)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Лабораторија за ауторизацију MCP клијента](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Користите Azure API Management екстензију за VS Code за увоз и управљање API-јима](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Региструјте и откријте удаљене MCP сервере у Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Одличан репозиторијум који показује многе AI могућности са Azure API Management
- [AI Gateway радионице](https://azure-samples.github.io/AI-Gateway/) Садржи радионице користећи Azure Portal, што је одличан начин за почетак евалуације AI могућности.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем услуге за превођење помоћу вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати ауторитативним извором. За критичне информације препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква погрешна тумачења или неспоразуме који могу произаћи из коришћења овог превода.
=======
- [Python пример: Сигурно повезивање удаљених MCP сервера користећи Azure API Management (експериментално)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Лабораторија за ауторизацију MCP клијента](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Коришћење Azure API Management екстензије за VS Code за увоз и управљање API-јима](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Регистрација и откривање удаљених MCP сервера у Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Одличан репозиторијум који приказује многе AI могућности са Azure API Management
- [AI Gateway радионице](https://azure-samples.github.io/AI-Gateway/) Садржи радионице користећи Azure Portal, што је одличан начин за почетак евалуације AI могућности.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем услуге за превођење помоћу вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације препоручује се професионални превод од стране људи. Не преузимамо одговорност за било каква погрешна тумачења или неспоразуме који могу настати услед коришћења овог превода.
>>>>>>> origin/main
