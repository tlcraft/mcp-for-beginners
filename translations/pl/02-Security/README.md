<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:16:40+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Wdrożenie Model Context Protocol (MCP) wprowadza potężne możliwości do aplikacji opartych na sztucznej inteligencji, ale jednocześnie niesie ze sobą unikalne wyzwania związane z bezpieczeństwem, wykraczające poza tradycyjne ryzyka oprogramowania. Oprócz znanych zagadnień, takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI stoją w obliczu nowych zagrożeń, takich jak prompt injection, tool poisoning czy dynamiczna modyfikacja narzędzi. Zaniedbanie tych kwestii może prowadzić do wycieku danych, naruszenia prywatności oraz niezamierzonego działania systemu.

Ta lekcja omawia najważniejsze zagrożenia bezpieczeństwa związane z MCP — w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie ataki prompt injection oraz luki w łańcuchu dostaw — oraz przedstawia praktyczne środki zaradcze i najlepsze praktyki, które pomogą je ograniczyć. Dowiesz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety i GitHub Advanced Security, aby wzmocnić implementację MCP. Dzięki zrozumieniu i zastosowaniu tych środków możesz znacząco zmniejszyć ryzyko naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną solidne i godne zaufania.

# Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wynikające z Model Context Protocol (MCP), takie jak prompt injection, tool poisoning, nadmierne uprawnienia i luki w łańcuchu dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla zagrożeń MCP, w tym solidne uwierzytelnianie, zasadę najmniejszych uprawnień, bezpieczne zarządzanie tokenami oraz weryfikację łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, w celu ochrony MCP i obciążeń AI.
- Docenić znaczenie walidacji metadanych narzędzi, monitorowania dynamicznych zmian oraz obrony przed pośrednimi atakami prompt injection.
- Włączyć ustalone najlepsze praktyki bezpieczeństwa — takie jak bezpieczne kodowanie, wzmacnianie serwerów i architektura zero trust — do swojej implementacji MCP, aby zmniejszyć prawdopodobieństwo i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do ważnych zasobów napotyka na wyzwania związane z bezpieczeństwem. Zwykle można je rozwiązać poprzez właściwe zastosowanie podstawowych mechanizmów i koncepcji bezpieczeństwa. Ponieważ MCP jest protokołem stosunkowo nowym i szybko ewoluuje, specyfikacja ciągle się zmienia. Z czasem kontrole bezpieczeństwa w nim zawarte będą dojrzewać, umożliwiając lepszą integrację z architekturami korporacyjnymi i sprawdzonymi praktykami bezpieczeństwa.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) pokazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnym praktykom higieny bezpieczeństwa, a najlepszą ochroną przed jakimkolwiek naruszeniem jest właściwe wdrożenie podstawowych zasad bezpieczeństwa, bezpiecznego kodowania oraz zabezpieczeń łańcucha dostaw — te sprawdzone metody nadal mają największy wpływ na ograniczenie ryzyka.

Przyjrzyjmy się teraz kilku sposobom, dzięki którym można zacząć przeciwdziałać zagrożeniom podczas wdrażania MCP.

> **Note:** Poniższe informacje są aktualne na dzień **29 maja 2025**. Protokół MCP ciągle się rozwija, a przyszłe implementacje mogą wprowadzać nowe wzorce uwierzytelniania i kontrole. Aby uzyskać najnowsze informacje i wytyczne, zawsze odwołuj się do [MCP Specification](https://spec.modelcontextprotocol.io/), oficjalnego [repozytorium MCP na GitHub](https://github.com/modelcontextprotocol) oraz [strony z najlepszymi praktykami bezpieczeństwa](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problemu  
Pierwotna specyfikacja MCP zakładała, że deweloperzy sami napiszą serwer uwierzytelniania. Wymagało to znajomości OAuth i związanych z nim ograniczeń bezpieczeństwa. Serwery MCP działały jako OAuth 2.0 Authorization Servers, zarządzając uwierzytelnianiem użytkowników bezpośrednio, zamiast delegować je do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od **26 kwietnia 2025** aktualizacja specyfikacji MCP pozwala serwerom MCP delegować uwierzytelnianie użytkowników do zewnętrznej usługi.

### Zagrożenia
- Błędnie skonfigurowana logika autoryzacji na serwerze MCP może prowadzić do wycieku wrażliwych danych i niewłaściwego stosowania kontroli dostępu.
- Kradzież tokena OAuth na lokalnym serwerze MCP. W przypadku kradzieży token może zostać użyty do podszywania się pod serwer MCP i uzyskania dostępu do zasobów i danych, do których token jest przypisany.

#### Token Passthrough
Token passthrough jest wyraźnie zabroniony w specyfikacji autoryzacji, ponieważ niesie ze sobą szereg zagrożeń, takich jak:

#### Omijanie kontroli bezpieczeństwa
Serwer MCP lub downstream API mogą implementować ważne kontrole bezpieczeństwa, takie jak ograniczanie liczby żądań, walidacja zapytań czy monitorowanie ruchu, które opierają się na odbiorcy tokena lub innych ograniczeniach poświadczeń. Jeśli klienci mogą uzyskać i używać tokenów bezpośrednio z downstream API bez odpowiedniej walidacji przez serwer MCP lub bez upewnienia się, że tokeny zostały wydane dla właściwej usługi, omijają te kontrole.

#### Problemy z odpowiedzialnością i audytem
Serwer MCP nie będzie w stanie zidentyfikować ani rozróżnić klientów MCP, gdy klienci wywołują usługi z tokenem dostępu wydanym upstream, który może być dla serwera MCP nieczytelny.
Logi downstream Resource Server mogą pokazywać żądania pochodzące z innego źródła o innej tożsamości, a nie z serwera MCP, który faktycznie przekazuje tokeny.
Oba te czynniki utrudniają dochodzenia incydentów, stosowanie kontroli i audyt.
Jeśli serwer MCP przekazuje tokeny bez walidacji ich roszczeń (np. ról, uprawnień czy odbiorcy) lub innych metadanych, złośliwy aktor posiadający skradziony token może użyć serwera jako pośrednika do wycieku danych.

#### Problemy z granicą zaufania
Downstream Resource Server ufa określonym podmiotom, zakładając ich pochodzenie lub wzorce zachowań klienta. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów.
Jeśli token jest akceptowany przez wiele usług bez odpowiedniej walidacji, atakujący, który przejmie jedną usługę, może użyć tokena do dostępu do innych powiązanych usług.

#### Ryzyko kompatybilności w przyszłości
Nawet jeśli serwer MCP działa dziś jako „czysty proxy”, może w przyszłości wymagać dodania kontroli bezpieczeństwa. Właściwe oddzielenie odbiorców tokenów od początku ułatwia rozwój modelu bezpieczeństwa.

### Środki zaradcze

**Serwery MCP NIE MOGĄ akceptować tokenów, które nie zostały wyraźnie wydane dla serwera MCP**

- **Przejrzyj i wzmocnij logikę autoryzacji:** Dokładnie audytuj implementację autoryzacji serwera MCP, aby zapewnić dostęp do wrażliwych zasobów tylko dla zamierzonych użytkowników i klientów. Praktyczne wskazówki znajdziesz na stronach [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Egzekwuj bezpieczne praktyki zarządzania tokenami:** Stosuj się do [najlepszych praktyk Microsoft dotyczących walidacji tokenów i ich okresu ważności](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiegać niewłaściwemu użyciu tokenów dostępu oraz zmniejszyć ryzyko powtórnego wykorzystania lub kradzieży tokenów.
- **Chroń przechowywanie tokenów:** Zawsze przechowuj tokeny w bezpieczny sposób i stosuj szyfrowanie, aby zabezpieczyć je zarówno w stanie spoczynku, jak i podczas transmisji. Wskazówki dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmierne uprawnienia dla serwerów MCP

### Opis problemu
Serwery MCP mogą mieć nadane zbyt szerokie uprawnienia do usług lub zasobów, do których się łączą. Na przykład serwer MCP będący częścią aplikacji AI sprzedaży, łączący się z korporacyjnym magazynem danych, powinien mieć dostęp ograniczony do danych sprzedażowych, a nie do wszystkich plików w magazynie. Odwołując się do zasady najmniejszych uprawnień (jednej z najstarszych zasad bezpieczeństwa), żaden zasób nie powinien mieć uprawnień wykraczających poza te niezbędne do wykonania przypisanych zadań. AI stanowi tu dodatkowe wyzwanie, ponieważ dla zapewnienia elastyczności trudno jest precyzyjnie określić potrzebne uprawnienia.

### Zagrożenia  
- Nadanie nadmiernych uprawnień może umożliwić wyciek lub modyfikację danych, do których serwer MCP nie powinien mieć dostępu. Może to również stanowić problem prywatności, jeśli dane zawierają informacje umożliwiające identyfikację osób (PII).

### Środki zaradcze
- **Stosuj zasadę najmniejszych uprawnień:** Przyznawaj serwerowi MCP tylko minimalne uprawnienia potrzebne do realizacji jego zadań. Regularnie przeglądaj i aktualizuj te uprawnienia, aby upewnić się, że nie przekraczają wymagań. Szczegółowe wytyczne znajdziesz na [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Używaj kontroli dostępu opartej na rolach (RBAC):** Przypisuj serwerowi MCP role ściśle powiązane z konkretnymi zasobami i działaniami, unikając szerokich lub niepotrzebnych uprawnień.
- **Monitoruj i audytuj uprawnienia:** Nieustannie obserwuj wykorzystanie uprawnień i analizuj logi dostępu, aby szybko wykrywać i usuwać nadmierne lub nieużywane uprawnienia.

# Pośrednie ataki prompt injection

### Opis problemu

Złośliwe lub przejęte serwery MCP mogą wprowadzać poważne zagrożenia, narażając dane klientów lub umożliwiając niezamierzone działania. Te ryzyka są szczególnie istotne w środowiskach AI i opartych na MCP, gdzie występują:

- **Ataki prompt injection:** Atakujący wprowadzają złośliwe instrukcje w promptach lub zewnętrznych treściach, powodując, że system AI wykonuje niezamierzone działania lub ujawnia wrażliwe dane. Więcej: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Atakujący manipulują metadanymi narzędzi (np. opisami lub parametrami), by wpłynąć na zachowanie AI, potencjalnie omijając kontrole bezpieczeństwa lub wykradając dane. Szczegóły: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Złośliwe instrukcje są osadzone w dokumentach, stronach internetowych lub mailach, które następnie przetwarzane są przez AI, prowadząc do wycieku lub manipulacji danymi.
- **Dynamiczna modyfikacja narzędzi (Rug Pulls):** Definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika, wprowadzając nowe, złośliwe zachowania bez jego wiedzy.

Te luki podkreślają konieczność solidnej walidacji, monitorowania i kontroli bezpieczeństwa przy integracji serwerów MCP i narzędzi w środowisku. Więcej informacji w powyższych linkach.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pl.png)

**Pośredni prompt injection** (znany również jako cross-domain prompt injection lub XPIA) to krytyczna luka w systemach generatywnej AI, w tym tych wykorzystujących Model Context Protocol (MCP). W tym ataku złośliwe instrukcje są ukryte w zewnętrznych treściach — takich jak dokumenty, strony internetowe czy e-maile. Gdy system AI je przetwarza, może interpretować te instrukcje jako prawidłowe polecenia użytkownika, prowadząc do niezamierzonych działań, takich jak wyciek danych, generowanie szkodliwych treści lub manipulacja interakcjami użytkownika. Szczegółowe wyjaśnienie i przykłady znajdziesz na [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Szczególnie niebezpieczną formą tego ataku jest **Tool Poisoning**. Atakujący wstrzykują złośliwe instrukcje do metadanych narzędzi MCP (np. opisów czy parametrów). Ponieważ duże modele językowe (LLM) opierają się na tych metadanych, aby zdecydować, które narzędzia wywołać, zmanipulowane opisy mogą oszukać model, by wykonał nieautoryzowane wywołania narzędzi lub ominął kontrole bezpieczeństwa. Takie manipulacje są często niewidoczne dla użytkowników końcowych, ale mogą być interpretowane i realizowane przez system AI. Ryzyko to jest szczególnie wysokie w środowiskach hostowanych MCP, gdzie definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika — sytuacja określana czasem jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". W takim scenariuszu narzędzie, które wcześniej było bezpieczne, może zostać później zmodyfikowane, by wykonywać złośliwe działania, takie jak wyciek danych czy zmiana zachowania systemu, bez wiedzy użytkownika. Więcej o tym wektorze ataku znajdziesz na [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pl.png)

## Zagrożenia
Niepożądane działania AI niosą ze sobą różne ryzyka bezpieczeństwa, w tym wyciek danych i naruszenia prywatności.

### Środki zaradcze
### Wykorzystanie prompt shields do ochrony przed pośrednimi atakami prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** to rozwiązanie opracowane przez Microsoft, które chroni przed zarówno bezpośrednimi, jak i pośrednimi atakami prompt injection. Działają one poprzez:

1.  **Wykrywanie i filtrowanie:** Prompt Shields wykorzystują zaawansowane algorytmy uczenia maszynowego oraz przetwarzania języka naturalnego do wykrywania i eliminowania złośliwych instrukcji osadzonych w zewnętrznych treściach, takich jak dokumenty, strony internetowe czy e-maile.
    
2.  **Spotlighting:** Ta technika pomaga systemowi AI rozróżnić prawidłowe instrukcje systemowe od potencjalnie niegodnych zaufania danych zewnętrznych. Poprzez transformację tekstu wejściowego w sposób bardziej istotny dla modelu, Spotlighting zapewnia, że AI lepiej identyfikuje i ignoruje złośliwe polecenia.
    
3.  **Delimitery i datamarking:** Umieszczanie delimiterów w wiadomości systemowej jasno określa lokalizację tekstu wejściowego, pomagając systemowi AI rozpoznać i oddzielić dane użytkownika od potencjalnie szkodliwych treści zewnętrznych. Datamarking rozszerza tę koncepcję, stosując specjalne znaczniki wyznaczające granice
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Następne

Następne: [Rozdział 3: Pierwsze kroki](/03-GettingStarted/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło wiarygodne i autorytatywne. W przypadku informacji o krytycznym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.