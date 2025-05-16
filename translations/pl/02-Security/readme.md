<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:45:15+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Wdrożenie Model Context Protocol (MCP) wnosi potężne nowe możliwości do aplikacji opartych na sztucznej inteligencji, ale jednocześnie wprowadza unikalne wyzwania bezpieczeństwa wykraczające poza tradycyjne zagrożenia związane z oprogramowaniem. Oprócz znanych zagadnień, takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI stają wobec nowych zagrożeń, takich jak prompt injection, tool poisoning czy dynamiczna modyfikacja narzędzi. Niewłaściwe zarządzanie tymi ryzykami może prowadzić do wycieku danych, naruszenia prywatności oraz niezamierzonego działania systemu.

W tej lekcji omówimy najważniejsze zagrożenia bezpieczeństwa związane z MCP — w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie ataki prompt injection oraz podatności łańcucha dostaw — oraz przedstawimy praktyczne środki zaradcze i najlepsze praktyki minimalizujące te ryzyka. Nauczysz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, aby wzmocnić swoją implementację MCP. Dzięki zrozumieniu i zastosowaniu tych środków możesz znacząco zmniejszyć prawdopodobieństwo naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną solidne i godne zaufania.

# Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wprowadzone przez Model Context Protocol (MCP), takie jak prompt injection, tool poisoning, nadmierne uprawnienia oraz podatności łańcucha dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla zagrożeń MCP, takie jak solidne uwierzytelnianie, zasada najmniejszych uprawnień, bezpieczne zarządzanie tokenami oraz weryfikacja łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, do ochrony MCP i obciążeń AI.
- Docenić znaczenie walidacji metadanych narzędzi, monitorowania dynamicznych zmian oraz obrony przed pośrednimi atakami prompt injection.
- Włączyć ustalone najlepsze praktyki bezpieczeństwa — takie jak bezpieczne kodowanie, wzmacnianie serwerów i architektura zero trust — do swojej implementacji MCP, aby ograniczyć ryzyko i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do ważnych zasobów niesie ze sobą wyzwania bezpieczeństwa. Zwykle można je rozwiązać przez właściwe zastosowanie podstawowych środków i koncepcji bezpieczeństwa. Ponieważ MCP jest protokołem dopiero co zdefiniowanym, jego specyfikacja szybko się zmienia i ewoluuje. Z czasem środki bezpieczeństwa w nim zawarte dojrzeją, umożliwiając lepszą integrację z architekturami korporacyjnymi i sprawdzonymi najlepszymi praktykami.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) wskazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnej higienie bezpieczeństwa, a najlepszą ochroną przed wszelkiego rodzaju naruszeniami jest właściwe stosowanie podstawowych praktyk: higiena bezpieczeństwa, bezpieczne kodowanie oraz bezpieczeństwo łańcucha dostaw — te sprawdzone metody nadal mają największy wpływ na zmniejszenie ryzyka.

Przyjrzyjmy się kilku sposobom, jak zacząć radzić sobie z zagrożeniami bezpieczeństwa przy wdrażaniu MCP.

# Uwierzytelnianie serwera MCP (jeśli Twoja implementacja MCP była przed 26 kwietnia 2025)

> **Note:** Poniższe informacje są aktualne na dzień 26 kwietnia 2025. Protokół MCP ciągle się rozwija, a przyszłe implementacje mogą wprowadzić nowe wzorce i środki uwierzytelniania. Aby uzyskać najnowsze aktualizacje i wytyczne, zawsze odwołuj się do [MCP Specification](https://spec.modelcontextprotocol.io/) oraz oficjalnego [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Opis problemu  
Pierwotna specyfikacja MCP zakładała, że deweloperzy napiszą własny serwer uwierzytelniania. Wymagało to znajomości OAuth i powiązanych ograniczeń bezpieczeństwa. Serwery MCP działały jako serwery autoryzacji OAuth 2.0, zarządzając uwierzytelnianiem użytkownika bezpośrednio, zamiast delegować je do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od 26 kwietnia 2025 aktualizacja specyfikacji MCP pozwala serwerom MCP delegować uwierzytelnianie użytkowników do zewnętrznej usługi.

### Ryzyka
- Błędna konfiguracja logiki autoryzacji w serwerze MCP może prowadzić do ujawnienia wrażliwych danych i niewłaściwego stosowania kontroli dostępu.
- Kradzież tokenów OAuth na lokalnym serwerze MCP. W przypadku kradzieży token może zostać użyty do podszycia się pod serwer MCP i uzyskania dostępu do zasobów oraz danych chronionych przez token OAuth.

### Środki zaradcze
- **Przejrzyj i wzmocnij logikę autoryzacji:** Dokładnie audytuj implementację autoryzacji w swoim serwerze MCP, aby zapewnić, że tylko zamierzeni użytkownicy i klienci mają dostęp do wrażliwych zasobów. W praktyce pomocne będą materiały [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Wymuszaj bezpieczne praktyki zarządzania tokenami:** Stosuj [najlepsze praktyki Microsoft dotyczące walidacji i czasu życia tokenów](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiec nadużyciom i zmniejszyć ryzyko powtórnego użycia lub kradzieży tokenów.
- **Chroń przechowywanie tokenów:** Przechowuj tokeny w sposób bezpieczny i stosuj szyfrowanie zarówno podczas przechowywania, jak i przesyłania. Wskazówki dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmierne uprawnienia serwerów MCP

### Opis problemu  
Serwery MCP mogły otrzymać nadmierne uprawnienia do usług lub zasobów, do których mają dostęp. Na przykład serwer MCP będący częścią aplikacji AI dla sprzedaży, łączący się z firmowym magazynem danych, powinien mieć dostęp ograniczony do danych sprzedażowych, a nie do wszystkich plików w magazynie. Zasada najmniejszych uprawnień (jedna z najstarszych zasad bezpieczeństwa) mówi, że żaden zasób nie powinien mieć uprawnień przekraczających te niezbędne do realizacji swoich zadań. AI stanowi tu dodatkowe wyzwanie, ponieważ dla zapewnienia elastyczności trudno jest precyzyjnie określić wymagane uprawnienia.

### Ryzyka  
- Nadanie zbyt szerokich uprawnień może umożliwić wykradanie lub modyfikację danych, do których serwer MCP nie powinien mieć dostępu. Może to też stanowić problem prywatności, jeśli dane zawierają informacje osobowe (PII).

### Środki zaradcze
- **Stosuj zasadę najmniejszych uprawnień:** Przyznawaj serwerowi MCP tylko minimalne uprawnienia niezbędne do realizacji jego zadań. Regularnie przeglądaj i aktualizuj te uprawnienia, aby nie przekraczały koniecznego zakresu. Szczegółowe wskazówki znajdziesz w [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Wykorzystuj Role-Based Access Control (RBAC):** Przypisuj serwerowi MCP role ściśle ograniczone do konkretnych zasobów i działań, unikając szerokich lub zbędnych uprawnień.
- **Monitoruj i audytuj uprawnienia:** Nieustannie śledź wykorzystanie uprawnień i audytuj logi dostępu, aby szybko wykrywać i usuwać nadmierne lub nieużywane przywileje.

# Pośrednie ataki prompt injection

### Opis problemu

Złośliwe lub przejęte serwery MCP mogą stwarzać poważne zagrożenia poprzez ujawnianie danych klientów lub umożliwianie niezamierzonych działań. Te zagrożenia są szczególnie istotne w środowiskach AI i opartych na MCP, gdzie występują:

- **Ataki prompt injection:** Atakujący umieszczają złośliwe instrukcje w promptach lub zewnętrznych treściach, powodując, że system AI wykonuje niezamierzone działania lub ujawnia wrażliwe dane. Więcej informacji: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool poisoning:** Atakujący manipulują metadanymi narzędzi (np. opisami lub parametrami), aby wpłynąć na zachowanie AI, potencjalnie omijając zabezpieczenia lub wykradając dane. Szczegóły: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Złośliwe instrukcje są osadzane w dokumentach, stronach internetowych lub e-mailach, które następnie są przetwarzane przez AI, co prowadzi do wycieku lub manipulacji danymi.
- **Dynamiczna modyfikacja narzędzi (Rug Pulls):** Definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika, wprowadzając nowe złośliwe zachowania bez jego wiedzy.

Te podatności podkreślają potrzebę solidnej walidacji, monitorowania i kontroli bezpieczeństwa podczas integrowania serwerów MCP i narzędzi w Twoim środowisku. Szczegółowe informacje znajdziesz w powyższych odnośnikach.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pl.png)

**Pośrednie prompt injection** (znane także jako cross-domain prompt injection lub XPIA) to krytyczna luka w systemach generatywnej AI, w tym tych korzystających z Model Context Protocol (MCP). W tym ataku złośliwe instrukcje są ukryte w zewnętrznych treściach — takich jak dokumenty, strony internetowe czy e-maile. Gdy system AI przetwarza takie treści, może błędnie interpretować ukryte instrukcje jako legalne polecenia użytkownika, co skutkuje niezamierzonymi działaniami, takimi jak wyciek danych, generowanie szkodliwych treści lub manipulacja interakcjami użytkownika. Szczegółowe wyjaśnienie i przykłady znajdziesz w [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Szczególnie niebezpieczną formą tego ataku jest **Tool Poisoning**. Atakujący wstrzykują złośliwe instrukcje do metadanych narzędzi MCP (np. opisów lub parametrów). Ponieważ duże modele językowe (LLM) opierają się na tych metadanych przy wyborze narzędzi do wywołania, skompromitowane opisy mogą nakłonić model do wykonywania nieautoryzowanych wywołań narzędzi lub omijania zabezpieczeń. Takie manipulacje są często niewidoczne dla użytkowników, ale mogą być interpretowane i realizowane przez system AI. Ryzyko to jest szczególnie wysokie w środowiskach hostowanych serwerów MCP, gdzie definicje narzędzi mogą być aktualizowane po zatwierdzeniu przez użytkownika — scenariusz ten bywa określany jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". W takich przypadkach narzędzie, które wcześniej było bezpieczne, może zostać zmodyfikowane, by wykonywać złośliwe działania, takie jak wykradanie danych czy zmiana zachowania systemu, bez wiedzy użytkownika. Więcej na temat tego wektora ataku znajdziesz w [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pl.png)

## Ryzyka  
Niepożądane działania AI niosą ze sobą różnorodne zagrożenia bezpieczeństwa, w tym wyciek danych i naruszenia prywatności.

### Środki zaradcze  
### Korzystanie z prompt shields w celu ochrony przed pośrednimi atakami prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** to rozwiązanie opracowane przez Microsoft, które chroni przed bezpośrednimi i pośrednimi atakami prompt injection. Działa poprzez:

1.  **Wykrywanie i filtrowanie:** Prompt Shields wykorzystują zaawansowane algorytmy uczenia maszynowego i przetwarzania języka naturalnego, aby wykrywać i filtrować złośliwe instrukcje ukryte w zewnętrznych treściach, takich jak dokumenty, strony internetowe czy e-maile.
    
2.  **Spotlighting:** Ta technika pomaga systemowi AI odróżnić prawidłowe instrukcje systemowe od potencjalnie niegodnych zaufania danych zewnętrznych. Poprzez przekształcenie tekstu wejściowego w sposób bardziej relewantny dla modelu, Spotlighting zapewnia, że AI lepiej identyfikuje i ignoruje złośliwe instrukcje.
    
3.  **Separatory i oznaczanie danych:** Włączenie separatorów w komunikacie systemowym wyraźnie określa miejsce tekstu wejściowego, pomagając AI rozróżnić dane użytkownika od potencjalnie szkodliwych treści zewnętrznych. Oznaczanie danych (datamarking) rozszerza tę koncepcję, stosując specjalne znaczniki wyznaczające granice danych zaufanych i niezaufanych.
    
4.  **Ciągłe monitorowanie i aktualizacje:** Microsoft stale monitoruje i aktualizuje Prompt Shields, aby przeciwdziałać nowym i rozwijającym się zagrożeniom. Takie proaktywne podejście zapewnia skuteczność obrony wobec najnowszych technik ataków.
    
5. **Integracja z Azure Content Safety:** Prompt Shields są częścią szerszego pakietu Azure AI Content Safety, który dostarcza dodatkowe narzędzia do wykrywania prób jailbreaków, szkodliwych treści i innych zagrożeń bezpieczeństwa w aplikacjach AI.

Więcej informacji o AI prompt shields znajdziesz w [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pl.png)

# Bezpieczeństwo łańcucha dostaw

Bezpieczeństwo łańcucha dostaw pozostaje kluczowe w erze AI, jednak zakres tego, co obejmuje łańcuch dostaw, znacznie się rozszerzył. Oprócz tradycyjnych pakietów kodu musisz teraz dokładnie weryfikować i monitorować wszystkie komponenty związane z AI, w tym modele bazowe, usługi embeddings, dostawców kontekstu oraz zewnętrzne API. Każdy z tych elementów może wprowadzać podatności lub ryzyka, jeśli nie jest odpowiednio zarządzany.

**Kluczowe praktyki bezpieczeństwa łańcucha dostaw dla AI i MCP:**
- **Weryfikuj wszystkie komponenty przed integracją:** Dotyczy to nie tylko bibliotek open source, ale także modeli AI, źródeł danych i zewnętrznych API. Zawsze sprawdzaj pochodzenie, licencje oraz znane podatności.
- **Utrzymuj bezpieczne pipeline'y wdrożeniowe:** Korzystaj z automatycznych pipeline’ów CI/CD zintegrowanych ze skanowaniem bezpieczeństwa, aby wykrywać problemy na wczesnym etapie. Zapewnij, że do produkcji trafiają tylko zaufane artefakty.
- **Monitoruj i audytuj na bieżąco:** Wdroż monitorowanie wszystkich zależności, w tym modeli i usług danych, aby wykrywać nowe podatności lub ataki na łańcuch dostaw.
- **Stosuj zasadę najmniejszych uprawnień i kontrolę dostępu:** Ograniczaj dostęp do modeli, danych i usług tylko do niezbędnego minimum, aby MCP działał poprawnie.
- **Szybko reaguj na zagro
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Dalej

Dalej: [Rozdział 3: Pierwsze kroki](/03-GettingStarted/README.md)

**Zastrzeżenie**:  
Ten dokument został przetłumaczony przy użyciu usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.