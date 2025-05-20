<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:07:03+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Wdrożenie Model Context Protocol (MCP) wprowadza potężne możliwości dla aplikacji opartych na sztucznej inteligencji, ale jednocześnie niesie ze sobą unikalne wyzwania związane z bezpieczeństwem, które wykraczają poza tradycyjne zagrożenia programistyczne. Oprócz znanych kwestii takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI stoją przed nowymi zagrożeniami, takimi jak prompt injection, tool poisoning czy dynamiczna modyfikacja narzędzi. Zaniedbanie tych ryzyk może prowadzić do wycieku danych, naruszeń prywatności oraz niezamierzonych zachowań systemu.

Ta lekcja omawia najważniejsze zagrożenia bezpieczeństwa związane z MCP — w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie ataki prompt injection oraz podatności łańcucha dostaw — i przedstawia praktyczne metody oraz najlepsze praktyki ich ograniczania. Dowiesz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, aby wzmocnić swoją implementację MCP. Zrozumienie i stosowanie tych mechanizmów pozwoli znacznie zmniejszyć ryzyko naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną niezawodne i godne zaufania.

# Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wprowadzone przez Model Context Protocol (MCP), takie jak prompt injection, tool poisoning, nadmierne uprawnienia oraz podatności łańcucha dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla ryzyk bezpieczeństwa MCP, takie jak solidne uwierzytelnianie, zasada najmniejszych uprawnień, bezpieczne zarządzanie tokenami oraz weryfikacja łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety i GitHub Advanced Security, do ochrony MCP i obciążeń AI.
- Docenić znaczenie walidacji metadanych narzędzi, monitorowania dynamicznych zmian oraz obrony przed pośrednimi atakami prompt injection.
- Włączyć sprawdzone najlepsze praktyki bezpieczeństwa — takie jak bezpieczne kodowanie, wzmacnianie serwerów oraz architekturę zero trust — do implementacji MCP, aby zmniejszyć prawdopodobieństwo i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do istotnych zasobów wiąże się z określonymi wyzwaniami bezpieczeństwa. Zazwyczaj można je rozwiązać poprzez prawidłowe stosowanie podstawowych mechanizmów i zasad bezpieczeństwa. Ponieważ MCP jest protokołem dopiero co zdefiniowanym, jego specyfikacja szybko się zmienia i będzie ewoluować. W efekcie środki bezpieczeństwa w nim zawarte będą się rozwijać, co pozwoli na lepszą integrację z architekturami korporacyjnymi oraz ugruntowanymi najlepszymi praktykami.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) wskazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnej higienie bezpieczeństwa. Najlepszą ochroną przed wszelkiego rodzaju naruszeniami jest zapewnienie właściwych podstawowych praktyk bezpieczeństwa — bezpieczne kodowanie, zasada najmniejszych uprawnień i bezpieczeństwo łańcucha dostaw — to sprawdzone metody, które wciąż mają największy wpływ na redukcję ryzyka.

Przyjrzyjmy się kilku sposobom, które pomogą Ci zacząć radzić sobie z zagrożeniami bezpieczeństwa przy wdrażaniu MCP.

# Uwierzytelnianie serwera MCP (jeśli Twoja implementacja MCP powstała przed 26 kwietnia 2025)

> **Note:** Poniższe informacje są aktualne na dzień 26 kwietnia 2025. Protokół MCP ciągle się rozwija, a przyszłe implementacje mogą wprowadzić nowe wzorce i mechanizmy uwierzytelniania. Aby uzyskać najnowsze informacje i wskazówki, zawsze odwołuj się do [MCP Specification](https://spec.modelcontextprotocol.io/) oraz oficjalnego [repozytorium MCP na GitHub](https://github.com/modelcontextprotocol).

### Opis problemu  
Pierwotna specyfikacja MCP zakładała, że deweloperzy sami napiszą własny serwer uwierzytelniania. Wymagało to znajomości OAuth i powiązanych ograniczeń bezpieczeństwa. Serwery MCP działały jako OAuth 2.0 Authorization Servers, zarządzając uwierzytelnianiem użytkowników bezpośrednio, zamiast delegować je do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od 26 kwietnia 2025 specyfikacja MCP została zaktualizowana, umożliwiając serwerom MCP delegowanie uwierzytelniania użytkowników do zewnętrznego serwisu.

### Ryzyka
- Błędna konfiguracja logiki autoryzacji na serwerze MCP może prowadzić do ujawnienia wrażliwych danych i nieprawidłowego stosowania kontroli dostępu.
- Kradzież tokena OAuth na lokalnym serwerze MCP. W przypadku kradzieży token może zostać użyty do podszywania się pod serwer MCP i uzyskania dostępu do zasobów i danych chronionych tym tokenem.

### Środki zaradcze
- **Przegląd i wzmocnienie logiki autoryzacji:** Dokładnie sprawdź implementację autoryzacji na serwerze MCP, aby upewnić się, że tylko uprawnieni użytkownicy i klienci mają dostęp do wrażliwych zasobów. Praktyczne wskazówki znajdziesz w [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Egzekwowanie bezpiecznych praktyk tokenów:** Stosuj się do [najlepszych praktyk Microsoft dotyczących walidacji i czasu życia tokenów](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiegać niewłaściwemu użyciu tokenów i zmniejszyć ryzyko ich powtórnego użycia lub kradzieży.
- **Ochrona przechowywania tokenów:** Zawsze przechowuj tokeny w sposób bezpieczny i stosuj szyfrowanie zarówno w spoczynku, jak i podczas przesyłu. Porady dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmierne uprawnienia dla serwerów MCP

### Opis problemu  
Serwery MCP mogą mieć przyznane zbyt szerokie uprawnienia do usług lub zasobów, z których korzystają. Na przykład serwer MCP w aplikacji sprzedażowej AI łączącej się z korporacyjnym magazynem danych powinien mieć dostęp ograniczony do danych sprzedażowych, a nie do wszystkich plików w magazynie. Odwołując się do zasady najmniejszych uprawnień (jednej z najstarszych zasad bezpieczeństwa), żaden zasób nie powinien mieć uprawnień wykraczających poza to, co jest niezbędne do wykonania przypisanych mu zadań. AI stawia tu dodatkowe wyzwania, ponieważ dla zapewnienia elastyczności trudno jest precyzyjnie określić wymagane uprawnienia.

### Ryzyka  
- Nadanie nadmiernych uprawnień może umożliwić wyciek lub modyfikację danych, do których serwer MCP nie powinien mieć dostępu. Może to także stanowić problem prywatności, jeśli dane zawierają informacje osobowe (PII).

### Środki zaradcze
- **Stosuj zasadę najmniejszych uprawnień:** Przyznawaj serwerowi MCP tylko minimalne uprawnienia potrzebne do realizacji jego zadań. Regularnie przeglądaj i aktualizuj te uprawnienia, aby nie przekraczały koniecznego zakresu. Szczegółowe wytyczne znajdziesz w [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Wykorzystuj Role-Based Access Control (RBAC):** Przypisuj serwerowi MCP role ściśle ograniczone do konkretnych zasobów i działań, unikając szerokich i niepotrzebnych uprawnień.
- **Monitoruj i audytuj uprawnienia:** Ciągłe monitorowanie wykorzystania uprawnień oraz audyt logów dostępu pozwala szybko wykryć i usunąć nadmierne lub nieużywane przywileje.

# Pośrednie ataki prompt injection

### Opis problemu

Złośliwe lub przejęte serwery MCP mogą powodować poważne zagrożenia, ujawniając dane klientów lub umożliwiając niezamierzone działania. Szczególnie dotyczy to obciążeń AI i MCP, gdzie występują:

- **Ataki prompt injection:** Atakujący wprowadzają złośliwe instrukcje w promptach lub zewnętrznej zawartości, powodując, że system AI wykonuje niezamierzone działania lub ujawnia wrażliwe dane. Więcej informacji: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Atakujący manipulują metadanymi narzędzi (takimi jak opisy lub parametry), wpływając na zachowanie AI, co może omijać zabezpieczenia lub prowadzić do wycieku danych. Szczegóły: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Złośliwe instrukcje są osadzone w dokumentach, stronach internetowych lub e-mailach, które następnie są przetwarzane przez AI, prowadząc do wycieku lub manipulacji danymi.
- **Dynamiczna modyfikacja narzędzi (Rug Pulls):** Definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika, wprowadzając nowe złośliwe zachowania bez jego wiedzy.

Te podatności podkreślają potrzebę solidnej walidacji, monitorowania i kontroli bezpieczeństwa podczas integracji serwerów MCP i narzędzi w środowisku. Szczegółowe informacje znajdziesz w podanych powyżej źródłach.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pl.png)

**Pośrednie prompt injection** (znane także jako cross-domain prompt injection lub XPIA) to krytyczna luka w systemach generatywnej AI, w tym tych korzystających z Model Context Protocol (MCP). W tym ataku złośliwe instrukcje są ukryte w zewnętrznej zawartości — takich jak dokumenty, strony internetowe czy e-maile. Gdy system AI przetwarza tę zawartość, może potraktować ukryte instrukcje jako prawidłowe polecenia użytkownika, co prowadzi do niezamierzonych działań, takich jak wyciek danych, generowanie szkodliwych treści czy manipulacja interakcjami z użytkownikiem. Szczegółowe wyjaśnienie i przykłady znajdziesz w [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Szczególnie niebezpieczną formą tego ataku jest **Tool Poisoning**. Atakujący wstrzykują złośliwe instrukcje do metadanych narzędzi MCP (np. opisy lub parametry narzędzi). Ponieważ modele językowe (LLM) opierają się na tych metadanych, aby zdecydować, które narzędzia wywołać, zmanipulowane opisy mogą oszukać model, by wykonał nieautoryzowane wywołania narzędzi lub ominął zabezpieczenia. Te manipulacje są często niewidoczne dla użytkowników, ale interpretowane i wykonywane przez system AI. Ryzyko jest szczególnie wysokie w środowiskach hostowanych serwerów MCP, gdzie definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika — sytuacja określana czasem jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". W takim scenariuszu narzędzie, które wcześniej było bezpieczne, może zostać zmodyfikowane, by wykonywać złośliwe działania, takie jak wyciek danych lub zmiana zachowania systemu, bez wiedzy użytkownika. Więcej o tym wektorze ataku znajdziesz w [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pl.png)

## Ryzyka
Niepożądane działania AI niosą ze sobą różnorodne zagrożenia bezpieczeństwa, w tym wyciek danych i naruszenia prywatności.

### Środki zaradcze
### Wykorzystanie prompt shields do ochrony przed pośrednimi atakami prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** to rozwiązanie opracowane przez Microsoft, które chroni przed bezpośrednimi i pośrednimi atakami prompt injection. Działa poprzez:

1.  **Wykrywanie i filtrowanie:** Prompt Shields wykorzystują zaawansowane algorytmy uczenia maszynowego oraz przetwarzanie języka naturalnego do wykrywania i usuwania złośliwych instrukcji osadzonych w zewnętrznej zawartości, takiej jak dokumenty, strony internetowe czy e-maile.
    
2.  **Spotlighting:** Ta technika pomaga systemowi AI rozróżnić prawidłowe instrukcje systemowe od potencjalnie niegodnych zaufania zewnętrznych danych wejściowych. Poprzez przekształcenie tekstu wejściowego w sposób bardziej istotny dla modelu, Spotlighting pozwala AI lepiej identyfikować i ignorować złośliwe polecenia.
    
3.  **Separatory i datamarking:** Włączenie separatorów w wiadomości systemowej wyraźnie określa miejsce tekstu wejściowego, pomagając AI rozpoznać i oddzielić dane użytkownika od potencjalnie szkodliwej zawartości zewnętrznej. Datamarking rozszerza tę koncepcję poprzez stosowanie specjalnych znaczników, które wyznaczają granice danych zaufanych i niepewnych.
    
4.  **Ciągłe monitorowanie i aktualizacje:** Microsoft nieustannie monitoruje i aktualizuje Prompt Shields, aby przeciwdziałać nowym i rozwijającym się zagrożeniom. Takie proaktywne podejście zapewnia skuteczność obrony wobec najnowszych technik ataku.
    
5. **Integracja z Azure Content Safety:** Prompt Shields są częścią szerszego zestawu narzędzi Azure AI Content Safety, który oferuje dodatkowe mechanizmy wykrywania prób jailbreaku, szkodliwej zawartości i innych zagrożeń bezpieczeństwa w aplikacjach AI.

Więcej informacji o AI prompt shields znajdziesz w [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pl.png)

### Bezpieczeństwo łańcucha dostaw

Bezpieczeństwo łańcucha dostaw pozostaje fundamentem w erze AI, jednak zakres tego, co obejmuje łańcuch dostaw, znacznie się rozszerzył. Poza tradycyjnymi pakietami kodu, teraz musisz rygorystycznie weryfikować i monitorować wszystkie komponenty związane z AI, w tym modele bazowe, usługi embeddingów, dostawców kontekstu oraz zewnętrzne API. Każdy z tych elementów może wprowadzać podatności lub zagrożenia, jeśli nie jest odpowiednio zarządzany.

**Kluczowe praktyki bezpieczeństwa łańcucha dostaw dla AI i MCP:**
- **Weryfikuj wszystkie komponenty przed integracją:** Dotyczy to nie tylko bibliotek open-source, ale także modeli AI, źródeł danych i zewnętrznych API. Zawsze sprawdzaj pochodzenie, licencje i znane podatności.
- **Utrzymuj bezpieczne pipeline’y wdrożeniowe:** Korzystaj z automatycznych CI/CD zintegrowanych ze skanowaniem bezpieczeństwa, aby wykrywać problemy na wczesnym etapie. Zapewnij, że do produkcji trafiają tylko zaufane artefakty.
- **Ciągłe monitorowanie i audyt:** Wdrażaj stałe monitorowanie wszystkich zależności, w tym modeli i usług danych, aby wykrywać nowe podatności lub ataki na łańcuch dostaw.
- **Stosuj zasadę najmniejszych uprawnień i kontrolę dostępu:** Ogranicz dostęp do modeli, danych i usług
- [OWASP Top 10 dla LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Droga do zabezpieczenia łańcucha dostaw oprogramowania w Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Bezpieczny dostęp o minimalnych uprawnieniach (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepsze praktyki dotyczące walidacji tokenów i czasu ich życia](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Używaj bezpiecznego przechowywania tokenów i szyfruj tokeny (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management jako brama uwierzytelniania dla MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Używanie Microsoft Entra ID do uwierzytelniania na serwerach MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Dalej

Dalej: [Rozdział 3: Pierwsze kroki](/03-GettingStarted/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło wiarygodne. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.