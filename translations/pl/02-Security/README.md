<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T17:13:20+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Wdrożenie Model Context Protocol (MCP) wprowadza potężne nowe możliwości dla aplikacji opartych na sztucznej inteligencji, ale jednocześnie niesie ze sobą unikalne wyzwania związane z bezpieczeństwem, wykraczające poza tradycyjne zagrożenia w oprogramowaniu. Oprócz znanych kwestii, takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI stają w obliczu nowych zagrożeń, takich jak prompt injection, tool poisoning czy dynamiczna modyfikacja narzędzi. Niewłaściwe zarządzanie tymi ryzykami może prowadzić do wycieku danych, naruszenia prywatności oraz niezamierzonych zachowań systemu.

Ta lekcja omawia najistotniejsze zagrożenia bezpieczeństwa związane z MCP — w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie ataki prompt injection oraz luki w łańcuchu dostaw — oraz przedstawia praktyczne środki zaradcze i najlepsze praktyki, które pomogą je ograniczyć. Dowiesz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, aby wzmocnić implementację MCP. Dzięki zrozumieniu i zastosowaniu tych mechanizmów możesz znacząco zmniejszyć ryzyko naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną solidne i godne zaufania.

# Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wprowadzone przez Model Context Protocol (MCP), w tym prompt injection, tool poisoning, nadmierne uprawnienia oraz luki w łańcuchu dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla zagrożeń bezpieczeństwa MCP, takie jak solidne uwierzytelnianie, zasada najmniejszych uprawnień, bezpieczne zarządzanie tokenami oraz weryfikacja łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, do ochrony MCP i obciążeń AI.
- Docenić znaczenie weryfikacji metadanych narzędzi, monitorowania dynamicznych zmian oraz obrony przed pośrednimi atakami prompt injection.
- Zintegrować sprawdzone najlepsze praktyki bezpieczeństwa — takie jak bezpieczne kodowanie, wzmacnianie serwerów i architektura zero trust — w implementacji MCP, aby zmniejszyć prawdopodobieństwo i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do ważnych zasobów wiąże się z określonymi wyzwaniami bezpieczeństwa. Zazwyczaj można je rozwiązać poprzez prawidłowe stosowanie podstawowych mechanizmów i zasad bezpieczeństwa. Ponieważ MCP jest protokołem dopiero co zdefiniowanym, jego specyfikacja szybko się zmienia i ewoluuje. W miarę rozwoju protokołu kontrole bezpieczeństwa będą się doskonalić, umożliwiając lepszą integrację z architekturami korporacyjnymi i sprawdzonymi praktykami bezpieczeństwa.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) wskazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnej higienie bezpieczeństwa, a najlepszą ochroną przed wszelkiego rodzaju naruszeniami jest prawidłowe wdrożenie podstawowych zasad bezpieczeństwa, bezpiecznego kodowania i zabezpieczeń łańcucha dostaw — te sprawdzone praktyki nadal mają największy wpływ na ograniczenie ryzyka.

Przyjrzyjmy się kilku sposobom, dzięki którym możesz zacząć radzić sobie z zagrożeniami bezpieczeństwa podczas wdrażania MCP.

> **Note:** Poniższe informacje są aktualne na dzień **29 maja 2025**. Protokół MCP jest ciągle rozwijany, a przyszłe implementacje mogą wprowadzać nowe wzorce uwierzytelniania i kontrole. Aby uzyskać najnowsze aktualizacje i wskazówki, zawsze odwołuj się do [specyfikacji MCP](https://spec.modelcontextprotocol.io/), oficjalnego [repozytorium MCP na GitHub](https://github.com/modelcontextprotocol) oraz [strony z najlepszymi praktykami bezpieczeństwa](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problemu  
Pierwotna specyfikacja MCP zakładała, że deweloperzy sami napiszą własny serwer uwierzytelniania. Wymagało to znajomości OAuth i powiązanych ograniczeń bezpieczeństwa. Serwery MCP działały jako serwery autoryzacyjne OAuth 2.0, zarządzając uwierzytelnianiem użytkowników bezpośrednio, zamiast delegować je do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od **26 kwietnia 2025** aktualizacja specyfikacji MCP pozwala serwerom MCP delegować uwierzytelnianie użytkowników do zewnętrznej usługi.

### Ryzyka
- Błędna konfiguracja logiki autoryzacji na serwerze MCP może prowadzić do ujawnienia wrażliwych danych i nieprawidłowego stosowania kontroli dostępu.
- Kradzież tokenów OAuth na lokalnym serwerze MCP. W przypadku kradzieży token może zostać użyty do podszywania się pod serwer MCP i uzyskania dostępu do zasobów i danych, do których token jest przeznaczony.

#### Token Passthrough  
Token passthrough jest wyraźnie zabroniony w specyfikacji autoryzacji, ponieważ wprowadza szereg zagrożeń bezpieczeństwa, w tym:

#### Obejście kontroli bezpieczeństwa  
Serwer MCP lub downstream API mogą implementować ważne mechanizmy bezpieczeństwa, takie jak ograniczanie liczby żądań, walidacja zapytań czy monitorowanie ruchu, które opierają się na odbiorcy tokena lub innych ograniczeniach poświadczeń. Jeśli klienci mogą bezpośrednio uzyskać i używać tokenów z downstream API bez odpowiedniej walidacji przez serwer MCP lub bez upewnienia się, że tokeny są wydane dla właściwej usługi, omijają te kontrole.

#### Problemy z odpowiedzialnością i śledzeniem  
Serwer MCP nie będzie w stanie zidentyfikować ani rozróżnić klientów MCP, gdy klienci wywołują API z tokenem dostępu wydanym upstream, który może być dla serwera MCP nieczytelny.  
Logi downstream Resource Server mogą pokazywać żądania pochodzące z innego źródła o innej tożsamości, a nie z serwera MCP, który faktycznie przekazuje tokeny.  
Oba te czynniki utrudniają dochodzenia incydentów, kontrolę i audyt.  
Jeśli serwer MCP przekazuje tokeny bez weryfikacji ich atrybutów (np. ról, uprawnień czy odbiorcy) lub innych metadanych, złośliwy aktor posiadający skradziony token może użyć serwera jako pośrednika do wycieku danych.

#### Problemy z granicą zaufania  
Downstream Resource Server ufa określonym podmiotom. To zaufanie może obejmować założenia dotyczące pochodzenia lub wzorców zachowań klienta. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów.  
Jeśli token jest akceptowany przez wiele usług bez odpowiedniej walidacji, atakujący, który przełamie jedną usługę, może użyć tokena do dostępu do innych powiązanych usług.

#### Ryzyko kompatybilności w przyszłości  
Nawet jeśli serwer MCP zaczyna jako „czysty proxy”, może w przyszłości potrzebować dodać kontrole bezpieczeństwa. Rozpoczęcie od właściwego rozdzielenia odbiorców tokenów ułatwia ewolucję modelu bezpieczeństwa.

### Środki zaradcze

**Serwery MCP NIE MOGĄ akceptować żadnych tokenów, które nie zostały wyraźnie wydane dla serwera MCP**

- **Przejrzyj i wzmocnij logikę autoryzacji:** Dokładnie audytuj implementację autoryzacji serwera MCP, aby upewnić się, że tylko zamierzeni użytkownicy i klienci mają dostęp do wrażliwych zasobów. Praktyczne wskazówki znajdziesz w [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Wymuszaj bezpieczne praktyki dotyczące tokenów:** Stosuj się do [najlepszych praktyk Microsoft dotyczących walidacji tokenów i ich czasu życia](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiec niewłaściwemu użyciu tokenów dostępu oraz zmniejszyć ryzyko powtórnego użycia lub kradzieży tokenów.
- **Chroń przechowywanie tokenów:** Zawsze przechowuj tokeny w bezpieczny sposób i stosuj szyfrowanie, aby zabezpieczyć je w spoczynku i podczas przesyłania. Wskazówki dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmierne uprawnienia dla serwerów MCP

### Opis problemu  
Serwery MCP mogą mieć przyznane nadmierne uprawnienia do usługi lub zasobu, do którego się łączą. Na przykład serwer MCP będący częścią aplikacji AI do sprzedaży, łączący się z korporacyjnym magazynem danych, powinien mieć dostęp ograniczony do danych sprzedażowych, a nie do wszystkich plików w magazynie. Odwołując się do zasady najmniejszych uprawnień (jednej z najstarszych zasad bezpieczeństwa), żaden zasób nie powinien mieć uprawnień przekraczających to, co jest niezbędne do wykonania przypisanych mu zadań. AI stanowi tu dodatkowe wyzwanie, ponieważ aby była elastyczna, trudno jest dokładnie określić wymagane uprawnienia.

### Ryzyka  
- Przyznanie nadmiernych uprawnień może umożliwić wyciek lub modyfikację danych, do których serwer MCP nie powinien mieć dostępu. Może to również stanowić problem prywatności, jeśli dane zawierają informacje osobowe (PII).

### Środki zaradcze  
- **Stosuj zasadę najmniejszych uprawnień:** Przyznawaj serwerowi MCP tylko minimalne uprawnienia niezbędne do wykonania jego zadań. Regularnie przeglądaj i aktualizuj te uprawnienia, aby upewnić się, że nie przekraczają potrzeb. Szczegółowe wskazówki znajdziesz w [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Używaj kontroli dostępu opartej na rolach (RBAC):** Przypisuj serwerowi MCP role ściśle ograniczone do konkretnych zasobów i działań, unikając szerokich lub niepotrzebnych uprawnień.
- **Monitoruj i audytuj uprawnienia:** Ciągle monitoruj wykorzystanie uprawnień i audytuj logi dostępu, aby szybko wykrywać i usuwać nadmierne lub nieużywane uprawnienia.

# Pośrednie ataki prompt injection

### Opis problemu

Złośliwe lub przejęte serwery MCP mogą wprowadzać poważne zagrożenia, narażając dane klientów lub umożliwiając niezamierzone działania. Ryzyka te są szczególnie istotne w obciążeniach AI i opartych na MCP, gdzie:

- **Ataki prompt injection:** Atakujący wprowadzają złośliwe instrukcje w promptach lub zewnętrznych treściach, powodując, że system AI wykonuje niezamierzone działania lub ujawnia wrażliwe dane. Więcej informacji: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Atakujący manipulują metadanymi narzędzi (takimi jak opisy czy parametry), aby wpłynąć na zachowanie AI, potencjalnie omijając kontrole bezpieczeństwa lub wyprowadzając dane. Szczegóły: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Złośliwe instrukcje są ukryte w dokumentach, stronach internetowych lub e-mailach, które następnie są przetwarzane przez AI, prowadząc do wycieku lub manipulacji danymi.
- **Dynamiczna modyfikacja narzędzi (Rug Pulls):** Definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika, wprowadzając nowe złośliwe zachowania bez jego wiedzy.

Te luki podkreślają potrzebę solidnej weryfikacji, monitorowania i kontroli bezpieczeństwa podczas integracji serwerów MCP i narzędzi w Twoim środowisku. Aby zgłębić temat, zobacz powyższe odnośniki.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pl.png)

**Pośrednie prompt injection** (znane również jako cross-domain prompt injection lub XPIA) to krytyczna luka w systemach generatywnej AI, w tym tych korzystających z Model Context Protocol (MCP). W tym ataku złośliwe instrukcje są ukryte w zewnętrznych treściach — takich jak dokumenty, strony internetowe czy e-maile. Gdy system AI przetwarza te treści, może interpretować ukryte instrukcje jako prawidłowe polecenia użytkownika, co skutkuje niezamierzonymi działaniami, takimi jak wyciek danych, generowanie szkodliwych treści czy manipulacja interakcjami użytkownika. Szczegółowe wyjaśnienie i przykłady znajdziesz w [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Szczególnie niebezpieczną formą tego ataku jest **Tool Poisoning**. Atakujący wstrzykują złośliwe instrukcje do metadanych narzędzi MCP (np. opisów lub parametrów). Ponieważ duże modele językowe (LLM) opierają się na tych metadanych, aby zdecydować, które narzędzia wywołać, zmanipulowane opisy mogą oszukać model, by wykonał nieautoryzowane wywołania narzędzi lub ominął kontrole bezpieczeństwa. Te manipulacje są często niewidoczne dla użytkowników końcowych, ale mogą być interpretowane i realizowane przez system AI. Ryzyko to jest szczególnie wysokie w środowiskach hostowanych serwerów MCP, gdzie definicje narzędzi mogą być aktualizowane po zatwierdzeniu przez użytkownika — scenariusz czasem określany jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". W takich przypadkach narzędzie, które wcześniej było bezpieczne, może zostać zmodyfikowane, by wykonywać złośliwe działania, takie jak wyciek danych lub zmiana zachowania systemu, bez wiedzy użytkownika. Więcej o tym wektorze ataku znajdziesz w [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pl.png)

## Ryzyka  
Niepożądane działania AI niosą ze sobą różnorodne zagrożenia bezpieczeństwa, w tym wyciek danych i naruszenia prywatności.

### Środki zaradcze  
### Wykorzystanie prompt shields do ochrony przed pośrednimi atakami prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** to rozwiązanie opracowane przez Microsoft, które chroni przed bezpośrednimi i pośrednimi atakami prompt injection. Pomagają one poprzez:

1.  **Wykrywanie i filtrowanie:** Prompt Shields wykorzystują zaawansowane algorytmy uczenia maszynowego i przetwarzania języka naturalnego do wykrywania i filtrowania złośliwych instrukcji ukrytych w zewnętrznych treściach, takich jak dokumenty, strony internetowe czy e-maile.
    
2.  **Spotlighting:** Ta technika pomaga systemowi AI odróżnić prawidłowe instrukcje systemowe od potencjalnie niegodnych zaufania danych zewnętrznych. Poprzez przekształcenie tekstu wejściowego w sposób bardziej istotny dla modelu, Spotlighting zapewnia, że AI lepiej identyfikuje i ignoruje złośliwe instrukcje.
    
3.  **Delimitery i datamarking:** Umieszczanie delimiterów w komunikacie systemowym wyraźnie określa lokalizację tekstu wejściowego, pomagając AI
Bezpieczeństwo łańcucha dostaw pozostaje kluczowe w erze AI, jednak zakres tego, co obejmuje Twój łańcuch dostaw, się rozszerzył. Oprócz tradycyjnych pakietów kodu, musisz teraz rygorystycznie weryfikować i monitorować wszystkie komponenty związane z AI, w tym modele bazowe, usługi osadzania, dostawców kontekstu oraz zewnętrzne API. Każdy z nich może wprowadzać luki bezpieczeństwa lub ryzyka, jeśli nie jest odpowiednio zarządzany.

**Kluczowe praktyki bezpieczeństwa łańcucha dostaw dla AI i MCP:**
- **Weryfikuj wszystkie komponenty przed integracją:** Dotyczy to nie tylko bibliotek open-source, ale także modeli AI, źródeł danych i zewnętrznych API. Zawsze sprawdzaj pochodzenie, licencje oraz znane podatności.
- **Utrzymuj bezpieczne pipeline’y wdrożeniowe:** Korzystaj z automatycznych pipeline’ów CI/CD z wbudowanym skanowaniem bezpieczeństwa, aby wykrywać problemy na wczesnym etapie. Upewnij się, że do produkcji trafiają tylko zaufane artefakty.
- **Monitoruj i audytuj na bieżąco:** Wdrażaj ciągły monitoring wszystkich zależności, w tym modeli i usług danych, aby wykrywać nowe podatności lub ataki na łańcuch dostaw.
- **Stosuj zasadę najmniejszych uprawnień i kontrolę dostępu:** Ogranicz dostęp do modeli, danych i usług tylko do niezbędnego minimum, potrzebnego do działania serwera MCP.
- **Reaguj szybko na zagrożenia:** Miej opracowany proces łatania lub wymiany skompromitowanych komponentów oraz rotacji sekretów lub poświadczeń w przypadku wykrycia naruszenia.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferuje funkcje takie jak skanowanie sekretów, skanowanie zależności oraz analizę CodeQL. Narzędzia te integrują się z [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), pomagając zespołom identyfikować i łagodzić podatności zarówno w kodzie, jak i komponentach łańcucha dostaw AI.

Microsoft wewnętrznie stosuje rozbudowane praktyki bezpieczeństwa łańcucha dostaw dla wszystkich swoich produktów. Dowiedz się więcej w [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Ugruntowane najlepsze praktyki bezpieczeństwa, które podniosą poziom bezpieczeństwa Twojej implementacji MCP

Każda implementacja MCP dziedziczy istniejący poziom bezpieczeństwa środowiska organizacji, na którym jest oparta, dlatego rozważając bezpieczeństwo MCP jako elementu Twoich systemów AI, zaleca się podniesienie ogólnego poziomu bezpieczeństwa. Poniższe sprawdzone kontrole bezpieczeństwa są szczególnie istotne:

- Bezpieczne praktyki kodowania w aplikacji AI – ochrona przed [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 dla LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), korzystanie z bezpiecznych sejfów na sekrety i tokeny, wdrażanie end-to-end bezpiecznej komunikacji między wszystkimi komponentami aplikacji itp.
- Utwardzanie serwera – stosuj MFA tam, gdzie to możliwe, regularnie aktualizuj poprawki, integruj serwer z zewnętrznym dostawcą tożsamości dla kontroli dostępu itp.
- Utrzymuj urządzenia, infrastrukturę i aplikacje na bieżąco z aktualizacjami i poprawkami
- Monitorowanie bezpieczeństwa – wdrażaj logowanie i monitoring aplikacji AI (w tym klienta/serwera MCP) oraz przesyłaj te logi do centralnego SIEM w celu wykrywania anomalii
- Architektura zero trust – izoluj komponenty za pomocą kontroli sieciowych i tożsamościowych w sposób logiczny, aby zminimalizować ruch boczny w przypadku kompromitacji aplikacji AI.

# Kluczowe wnioski

- Podstawy bezpieczeństwa pozostają kluczowe: bezpieczne kodowanie, zasada najmniejszych uprawnień, weryfikacja łańcucha dostaw oraz ciągły monitoring są niezbędne dla MCP i obciążeń AI.
- MCP wprowadza nowe ryzyka — takie jak wstrzykiwanie promptów, zatruwanie narzędzi i nadmierne uprawnienia — które wymagają zarówno tradycyjnych, jak i specyficznych dla AI środków kontroli.
- Stosuj solidne praktyki uwierzytelniania, autoryzacji i zarządzania tokenami, wykorzystując zewnętrznych dostawców tożsamości, takich jak Microsoft Entra ID, tam gdzie to możliwe.
- Chroń się przed pośrednim wstrzykiwaniem promptów i zatruwaniem narzędzi, weryfikując metadane narzędzi, monitorując dynamiczne zmiany oraz korzystając z rozwiązań takich jak Microsoft Prompt Shields.
- Traktuj wszystkie komponenty w łańcuchu dostaw AI — w tym modele, osadzenia i dostawców kontekstu — z taką samą starannością jak zależności kodu.
- Bądź na bieżąco z ewoluującymi specyfikacjami MCP i angażuj się w społeczność, aby pomagać kształtować bezpieczne standardy.

# Dodatkowe zasoby

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
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

### Następny

Następny: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.