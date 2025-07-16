<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T22:41:38+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Wdrożenie Model Context Protocol (MCP) wprowadza potężne nowe możliwości dla aplikacji opartych na sztucznej inteligencji, ale jednocześnie niesie ze sobą unikalne wyzwania związane z bezpieczeństwem, wykraczające poza tradycyjne ryzyka programistyczne. Oprócz znanych zagadnień, takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI stają w obliczu nowych zagrożeń, takich jak wstrzykiwanie promptów, zatruwanie narzędzi, dynamiczna modyfikacja narzędzi, przejmowanie sesji, ataki typu confused deputy oraz podatności związane z przekazywaniem tokenów. Niewłaściwe zarządzanie tymi ryzykami może prowadzić do wycieku danych, naruszeń prywatności oraz niezamierzonych zachowań systemu.

Ta lekcja omawia najistotniejsze zagrożenia bezpieczeństwa związane z MCP — w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie wstrzykiwanie promptów, bezpieczeństwo sesji, problemy typu confused deputy, podatności związane z przekazywaniem tokenów oraz zagrożenia łańcucha dostaw — oraz przedstawia praktyczne środki zaradcze i najlepsze praktyki, które pomogą je złagodzić. Dowiesz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, aby wzmocnić implementację MCP. Dzięki zrozumieniu i zastosowaniu tych środków możesz znacząco zmniejszyć ryzyko naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną solidne i godne zaufania.

# Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wprowadzone przez Model Context Protocol (MCP), w tym wstrzykiwanie promptów, zatruwanie narzędzi, nadmierne uprawnienia, przejmowanie sesji, problemy typu confused deputy, podatności związane z przekazywaniem tokenów oraz zagrożenia łańcucha dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla zagrożeń bezpieczeństwa MCP, takie jak solidne uwierzytelnianie, zasada najmniejszych uprawnień, bezpieczne zarządzanie tokenami, kontrola bezpieczeństwa sesji oraz weryfikacja łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety oraz GitHub Advanced Security, do ochrony MCP i obciążeń AI.
- Docenić znaczenie weryfikacji metadanych narzędzi, monitorowania dynamicznych zmian, obrony przed pośrednimi atakami wstrzykiwania promptów oraz zapobiegania przejmowaniu sesji.
- Zintegrować ustalone najlepsze praktyki bezpieczeństwa — takie jak bezpieczne kodowanie, wzmacnianie serwerów i architektura zero trust — w implementacji MCP, aby zmniejszyć prawdopodobieństwo i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do ważnych zasobów niesie ze sobą wyzwania związane z bezpieczeństwem. Zazwyczaj można je rozwiązać poprzez prawidłowe stosowanie podstawowych kontroli i koncepcji bezpieczeństwa. Ponieważ MCP jest protokołem dopiero co zdefiniowanym, jego specyfikacja szybko się zmienia i ewoluuje. W miarę rozwoju protokołu kontrole bezpieczeństwa w nim zawarte będą dojrzewać, umożliwiając lepszą integrację z architekturami bezpieczeństwa przedsiębiorstw i ustalonymi najlepszymi praktykami.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) wskazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnej higienie bezpieczeństwa, a najlepszą ochroną przed wszelkiego rodzaju naruszeniami jest prawidłowe wdrożenie podstawowych zasad bezpieczeństwa, bezpiecznego kodowania i zabezpieczeń łańcucha dostaw — te sprawdzone praktyki nadal mają największy wpływ na zmniejszenie ryzyka.

Przyjrzyjmy się kilku sposobom, dzięki którym możesz zacząć adresować zagrożenia bezpieczeństwa podczas wdrażania MCP.

> **Note:** Poniższe informacje są aktualne na dzień **29 maja 2025**. Protokół MCP ciągle się rozwija, a przyszłe implementacje mogą wprowadzać nowe wzorce uwierzytelniania i kontrole. Aby uzyskać najnowsze aktualizacje i wskazówki, zawsze odwołuj się do [specyfikacji MCP](https://spec.modelcontextprotocol.io/) oraz oficjalnego [repozytorium MCP na GitHub](https://github.com/modelcontextprotocol) i [strony najlepszych praktyk bezpieczeństwa](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problemu  
Pierwotna specyfikacja MCP zakładała, że deweloperzy napiszą własny serwer uwierzytelniania. Wymagało to znajomości OAuth i powiązanych ograniczeń bezpieczeństwa. Serwery MCP działały jako serwery autoryzacyjne OAuth 2.0, zarządzając bezpośrednio uwierzytelnianiem użytkowników, zamiast delegować je do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od **26 kwietnia 2025** aktualizacja specyfikacji MCP pozwala serwerom MCP delegować uwierzytelnianie użytkowników do zewnętrznej usługi.

### Ryzyka
- Błędna konfiguracja logiki autoryzacji na serwerze MCP może prowadzić do ujawnienia wrażliwych danych i nieprawidłowego stosowania kontroli dostępu.
- Kradzież tokenów OAuth na lokalnym serwerze MCP. Po kradzieży token może zostać użyty do podszywania się pod serwer MCP i uzyskania dostępu do zasobów i danych, do których token OAuth uprawnia.

#### Token Passthrough  
Przekazywanie tokenów jest wyraźnie zabronione w specyfikacji autoryzacji, ponieważ wprowadza szereg zagrożeń bezpieczeństwa, w tym:

#### Obejście kontroli bezpieczeństwa  
Serwer MCP lub downstream API mogą implementować ważne kontrole bezpieczeństwa, takie jak ograniczanie liczby żądań, walidacja żądań czy monitorowanie ruchu, które zależą od odbiorcy tokena lub innych ograniczeń poświadczeń. Jeśli klienci mogą uzyskać i używać tokenów bezpośrednio z downstream API bez odpowiedniej walidacji przez serwer MCP lub bez upewnienia się, że tokeny zostały wydane dla właściwej usługi, omijają te kontrole.

#### Problemy z odpowiedzialnością i śledzeniem  
Serwer MCP nie będzie w stanie zidentyfikować ani rozróżnić klientów MCP, gdy klienci wywołują z tokenem dostępu wydanym upstream, który może być dla serwera MCP nieczytelny.  
Logi downstream Resource Server mogą pokazywać żądania pochodzące z innego źródła o innej tożsamości, a nie z serwera MCP, który faktycznie przekazuje tokeny.  
Oba te czynniki utrudniają dochodzenia incydentów, kontrolę i audyt.  
Jeśli serwer MCP przekazuje tokeny bez weryfikacji ich atrybutów (np. ról, uprawnień czy odbiorcy) lub innych metadanych, złośliwy aktor posiadający skradziony token może użyć serwera jako proxy do wycieku danych.

#### Problemy z granicą zaufania  
Downstream Resource Server udziela zaufania określonym podmiotom. To zaufanie może obejmować założenia dotyczące pochodzenia lub wzorców zachowań klienta. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów.  
Jeśli token jest akceptowany przez wiele usług bez odpowiedniej walidacji, atakujący, który przełamie jedną usługę, może użyć tokena do dostępu do innych powiązanych usług.

#### Ryzyko kompatybilności w przyszłości  
Nawet jeśli serwer MCP zaczyna dziś jako „czysty proxy”, może w przyszłości potrzebować dodać kontrole bezpieczeństwa. Rozpoczęcie od właściwego rozdzielenia odbiorców tokenów ułatwia ewolucję modelu bezpieczeństwa.

### Środki zaradcze

**Serwery MCP NIE MOGĄ akceptować żadnych tokenów, które nie zostały wyraźnie wydane dla serwera MCP**

- **Przejrzyj i wzmocnij logikę autoryzacji:** Dokładnie audytuj implementację autoryzacji swojego serwera MCP, aby upewnić się, że tylko zamierzeni użytkownicy i klienci mają dostęp do wrażliwych zasobów. Praktyczne wskazówki znajdziesz w [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Wymuszaj bezpieczne praktyki dotyczące tokenów:** Stosuj się do [najlepszych praktyk Microsoft dotyczących walidacji tokenów i ich czasu życia](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiec niewłaściwemu użyciu tokenów dostępu oraz zmniejszyć ryzyko powtórnego użycia lub kradzieży tokenów.
- **Chroń przechowywanie tokenów:** Zawsze przechowuj tokeny w sposób bezpieczny i stosuj szyfrowanie, aby zabezpieczyć je w spoczynku i podczas transmisji. Wskazówki dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmierne uprawnienia dla serwerów MCP

### Opis problemu  
Serwery MCP mogą mieć przyznane nadmierne uprawnienia do usługi lub zasobu, do którego uzyskują dostęp. Na przykład serwer MCP będący częścią aplikacji sprzedażowej AI łączącej się z firmowym magazynem danych powinien mieć dostęp ograniczony do danych sprzedażowych, a nie do wszystkich plików w magazynie. Odwołując się do zasady najmniejszych uprawnień (jednej z najstarszych zasad bezpieczeństwa), żaden zasób nie powinien mieć uprawnień przekraczających to, co jest niezbędne do wykonania przypisanych mu zadań. AI stanowi tu dodatkowe wyzwanie, ponieważ aby była elastyczna, trudno jest dokładnie określić wymagane uprawnienia.

### Ryzyka  
- Przyznanie nadmiernych uprawnień może umożliwić wyciek lub modyfikację danych, do których serwer MCP nie powinien mieć dostępu. Może to również stanowić problem prywatności, jeśli dane zawierają informacje umożliwiające identyfikację osób (PII).

### Środki zaradcze  
- **Stosuj zasadę najmniejszych uprawnień:** Przyznawaj serwerowi MCP tylko minimalne uprawnienia niezbędne do wykonania wymaganych zadań. Regularnie przeglądaj i aktualizuj te uprawnienia, aby upewnić się, że nie przekraczają potrzeb. Szczegółowe wskazówki znajdziesz w [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Używaj kontroli dostępu opartej na rolach (RBAC):** Przypisuj serwerowi MCP role ściśle ograniczone do konkretnych zasobów i działań, unikając szerokich lub niepotrzebnych uprawnień.
- **Monitoruj i audytuj uprawnienia:** Ciągle monitoruj wykorzystanie uprawnień i audytuj logi dostępu, aby szybko wykrywać i usuwać nadmierne lub nieużywane uprawnienia.

# Pośrednie ataki wstrzykiwania promptów

### Opis problemu

Złośliwe lub przejęte serwery MCP mogą wprowadzać poważne zagrożenia, narażając dane klientów lub umożliwiając niezamierzone działania. Te zagrożenia są szczególnie istotne w obciążeniach AI i opartych na MCP, gdzie:

- **Ataki wstrzykiwania promptów:** Atakujący umieszczają złośliwe instrukcje w promptach lub zewnętrznych treściach, powodując, że system AI wykonuje niezamierzone działania lub ujawnia wrażliwe dane. Więcej informacji: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Zatruwanie narzędzi:** Atakujący manipulują metadanymi narzędzi (takimi jak opisy czy parametry), aby wpłynąć na zachowanie AI, potencjalnie omijając kontrole bezpieczeństwa lub wyprowadzając dane. Szczegóły: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Wstrzykiwanie promptów między domenami:** Złośliwe instrukcje są osadzone w dokumentach, stronach internetowych lub e-mailach, które następnie są przetwarzane przez AI, prowadząc do wycieku lub manipulacji danymi.
- **Dynamiczna modyfikacja narzędzi (Rug Pulls):** Definicje narzędzi mogą być zmieniane po zatwierdzeniu przez użytkownika, wprowadzając nowe złośliwe zachowania bez jego wiedzy.

Te podatności podkreślają potrzebę solidnej walidacji, monitorowania i kontroli bezpieczeństwa podczas integracji serwerów MCP i narzędzi w Twoim środowisku. Aby zgłębić temat, zobacz powyższe linki.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pl.png)

**Pośrednie wstrzykiwanie promptów** (znane również jako wstrzykiwanie promptów między domenami lub XPIA) to krytyczna luka w systemach generatywnej AI, w tym tych korzystających z Model Context Protocol (MCP). W tym ataku złośliwe instrukcje są ukryte w zewnętrznych treściach — takich jak dokumenty, strony internetowe czy e-maile. Gdy system AI przetwarza te treści, może interpretować osadzone instrukcje jako prawidłowe polecenia użytkownika, co skutkuje niezamierzonymi działaniami, takimi jak wyciek danych, generowanie szkodliwych treści czy manipulacja interakcjami użytkownika. Szczegółowe wyjaśnienie i przykłady z życia znajdziesz w [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Szczególnie niebezpieczną formą tego ataku jest **Zatruwanie narzędzi**. Atakujący wstrzykują złośliwe instrukcje do metadanych narzędzi MCP (np. opisów lub parametrów). Ponieważ duże modele językowe (LLM) opierają się na tych metadanych, aby zdecydować, które narzędzia wywołać, zmanipulowane opisy mogą oszukać model, by wykonał nieautoryzowane wywołania narzędzi lub ominął kontrole bezpieczeństwa. Te manipulacje są często niewidoczne dla użytkowników końcowych, ale mogą być interpretowane i realizowane przez system AI. Ryzyko to jest szczególnie wysokie w środowiskach hostowanych serwerów MCP, gdzie definicje narzędzi mogą być aktualizowane po zatwierdzeniu przez użytkownika — scenariusz czasem określany jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". W takich przypadkach narzędzie, które wcześniej było bezpieczne, może zostać później zmodyfikowane, by wykonywać złośliwe działania, takie jak wyciek danych lub zmiana zachowania systemu, bez wiedzy użytkownika. Więcej o tym wektorze ataku znajdziesz w [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pl.png)

## Ryzyka  
Niepożądane działania AI niosą ze sobą różnorodne zagrożenia bezpieczeństwa, w tym wyciek danych i naruszenia prywatności.

### Środki zaradcze  
### Wykorzystanie prompt shields do ochrony przed pośrednimi atakami wstrzykiwania promptów
-----------------------------------------------------------------------------

**AI Prompt Shields** to rozwiązanie opracowane przez Microsoft, które chroni przed bezpośrednimi i pośrednimi atakami wstrzykiwania promptów. Pomagają one poprzez:

1.  **Wykrywanie i filtrowanie:** Prompt Shields wykorzystują zaawansowane algorytmy uczenia maszynowego i przetwarzania języka naturalnego do wykrywania i filt
Problem confused deputy to luka bezpieczeństwa, która występuje, gdy serwer MCP działa jako pośrednik między klientami MCP a zewnętrznymi API. Luka ta może być wykorzystana, gdy serwer MCP używa statycznego identyfikatora klienta do uwierzytelniania się u zewnętrznego serwera autoryzacji, który nie obsługuje dynamicznej rejestracji klientów.

### Ryzyka

- **Omijanie zgody oparte na ciasteczkach**: Jeśli użytkownik wcześniej uwierzytelnił się przez serwer proxy MCP, zewnętrzny serwer autoryzacji może ustawić ciasteczko zgody w przeglądarce użytkownika. Atakujący może później wykorzystać to, wysyłając użytkownikowi złośliwy link z przygotowanym żądaniem autoryzacji zawierającym złośliwy URI przekierowania.
- **Kradzież kodu autoryzacyjnego**: Po kliknięciu przez użytkownika złośliwego linku, zewnętrzny serwer autoryzacji może pominąć ekran zgody z powodu istniejącego ciasteczka, a kod autoryzacyjny może zostać przekierowany na serwer atakującego.
- **Nieautoryzowany dostęp do API**: Atakujący może wymienić skradziony kod autoryzacyjny na tokeny dostępu i podszyć się pod użytkownika, uzyskując dostęp do zewnętrznego API bez wyraźnej zgody.

### Środki zaradcze

- **Wymaganie wyraźnej zgody**: Serwery proxy MCP używające statycznych identyfikatorów klienta **MUSZĄ** uzyskać zgodę użytkownika dla każdego dynamicznie zarejestrowanego klienta przed przekazaniem żądania do zewnętrznych serwerów autoryzacji.
- **Poprawna implementacja OAuth**: Stosuj najlepsze praktyki bezpieczeństwa OAuth 2.1, w tym używanie wyzwań kodu (PKCE) w żądaniach autoryzacji, aby zapobiec atakom przechwycenia.
- **Weryfikacja klienta**: Wdrożenie ścisłej walidacji URI przekierowań i identyfikatorów klientów, aby zapobiec wykorzystaniu przez złośliwych aktorów.


# Luki w przekazywaniu tokenów

### Opis problemu

„Token passthrough” to antywzorzec, w którym serwer MCP akceptuje tokeny od klienta MCP bez weryfikacji, czy tokeny zostały prawidłowo wydane dla samego serwera MCP, a następnie „przekazuje je dalej” do downstream API. Praktyka ta jawnie narusza specyfikację autoryzacji MCP i wprowadza poważne ryzyka bezpieczeństwa.

### Ryzyka

- **Omijanie kontroli bezpieczeństwa**: Klienci mogą ominąć ważne mechanizmy bezpieczeństwa, takie jak ograniczenia liczby żądań, walidacja żądań czy monitorowanie ruchu, jeśli mogą używać tokenów bezpośrednio z downstream API bez odpowiedniej weryfikacji.
- **Problemy z odpowiedzialnością i audytem**: Serwer MCP nie będzie w stanie zidentyfikować ani rozróżnić klientów MCP, gdy klienci używają tokenów dostępu wydanych upstream, co utrudnia dochodzenia incydentów i audyt.
- **Eksfiltracja danych**: Jeśli tokeny są przekazywane bez odpowiedniej walidacji roszczeń, złośliwy aktor ze skradzionym tokenem może użyć serwera jako proxy do eksfiltracji danych.
- **Naruszenia granic zaufania**: Serwery zasobów downstream mogą ufać określonym podmiotom na podstawie założeń dotyczących pochodzenia lub wzorców zachowań. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów bezpieczeństwa.
- **Niewłaściwe użycie tokenów w wielu usługach**: Jeśli tokeny są akceptowane przez wiele usług bez odpowiedniej weryfikacji, atakujący, który przejął jedną usługę, może użyć tokenu do dostępu do innych powiązanych usług.

### Środki zaradcze

- **Weryfikacja tokenów**: Serwery MCP **NIE MOGĄ** akceptować tokenów, które nie zostały wyraźnie wydane dla samego serwera MCP.
- **Weryfikacja odbiorcy (audience)**: Zawsze sprawdzaj, czy tokeny mają poprawne roszczenie audience odpowiadające tożsamości serwera MCP.
- **Poprawne zarządzanie cyklem życia tokenów**: Wdrażaj krótkotrwałe tokeny dostępu oraz odpowiednie praktyki rotacji tokenów, aby zmniejszyć ryzyko kradzieży i niewłaściwego użycia tokenów.


# Przejęcie sesji

### Opis problemu

Przejęcie sesji to wektor ataku, w którym klient otrzymuje od serwera identyfikator sesji, a nieuprawniona osoba uzyskuje i używa tego samego identyfikatora sesji, aby podszyć się pod oryginalnego klienta i wykonać nieautoryzowane działania w jego imieniu. Jest to szczególnie niebezpieczne w stanowych serwerach HTTP obsługujących żądania MCP.

### Ryzyka

- **Wstrzyknięcie polecenia przez przejęcie sesji**: Atakujący, który uzyska identyfikator sesji, może wysyłać złośliwe zdarzenia do serwera współdzielącego stan sesji z serwerem, z którym połączony jest klient, potencjalnie wywołując szkodliwe działania lub uzyskując dostęp do wrażliwych danych.
- **Podszywanie się przez przejęcie sesji**: Atakujący ze skradzionym identyfikatorem sesji może wykonywać wywołania bezpośrednio do serwera MCP, omijając uwierzytelnianie i będąc traktowanym jak prawowity użytkownik.
- **Skompromitowane strumienie z możliwością wznawiania**: Gdy serwer obsługuje ponowne dostarczanie/wznawialne strumienie, atakujący może przedwcześnie zakończyć żądanie, które następnie zostanie wznowione przez oryginalnego klienta z potencjalnie złośliwą zawartością.

### Środki zaradcze

- **Weryfikacja autoryzacji**: Serwery MCP implementujące autoryzację **MUSZĄ** weryfikować wszystkie przychodzące żądania i **NIE MOGĄ** używać sesji do uwierzytelniania.
- **Bezpieczne identyfikatory sesji**: Serwery MCP **MUSZĄ** używać bezpiecznych, niedeterministycznych identyfikatorów sesji generowanych za pomocą bezpiecznych generatorów liczb losowych. Unikaj przewidywalnych lub sekwencyjnych identyfikatorów.
- **Powiązanie sesji z użytkownikiem**: Serwery MCP **POWINNY** powiązać identyfikatory sesji z informacjami specyficznymi dla użytkownika, łącząc identyfikator sesji z unikalnymi danymi użytkownika (np. jego wewnętrznym ID) w formacie `
<user_id>:<session_id>`.
- **Wygasanie sesji**: Wdrożenie odpowiedniego wygasania i rotacji sesji, aby ograniczyć okno podatności w przypadku kompromitacji identyfikatora sesji.
- **Bezpieczeństwo transportu**: Zawsze używaj HTTPS do całej komunikacji, aby zapobiec przechwyceniu identyfikatorów sesji.


# Bezpieczeństwo łańcucha dostaw

Bezpieczeństwo łańcucha dostaw pozostaje kluczowe w erze AI, ale zakres tego, co stanowi Twój łańcuch dostaw, się rozszerzył. Oprócz tradycyjnych pakietów kodu, musisz teraz rygorystycznie weryfikować i monitorować wszystkie komponenty związane z AI, w tym modele bazowe, usługi embeddingów, dostawców kontekstu oraz zewnętrzne API. Każdy z nich może wprowadzać luki lub ryzyka, jeśli nie jest odpowiednio zarządzany.

**Kluczowe praktyki bezpieczeństwa łańcucha dostaw dla AI i MCP:**
- **Weryfikuj wszystkie komponenty przed integracją:** Dotyczy to nie tylko bibliotek open-source, ale także modeli AI, źródeł danych i zewnętrznych API. Zawsze sprawdzaj pochodzenie, licencje i znane luki bezpieczeństwa.
- **Utrzymuj bezpieczne pipeline'y wdrożeniowe:** Korzystaj z automatycznych pipeline'ów CI/CD z wbudowanym skanowaniem bezpieczeństwa, aby wykrywać problemy na wczesnym etapie. Upewnij się, że do produkcji trafiają tylko zaufane artefakty.
- **Ciągłe monitorowanie i audyt:** Wdrażaj stały monitoring wszystkich zależności, w tym modeli i usług danych, aby wykrywać nowe luki lub ataki na łańcuch dostaw.
- **Stosuj zasadę najmniejszych uprawnień i kontrolę dostępu:** Ogranicz dostęp do modeli, danych i usług tylko do niezbędnego minimum dla działania serwera MCP.
- **Szybka reakcja na zagrożenia:** Miej procedury na łatki lub wymianę skompromitowanych komponentów oraz rotację sekretów lub poświadczeń w przypadku wykrycia naruszenia.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferuje funkcje takie jak skanowanie sekretów, skanowanie zależności i analizę CodeQL. Narzędzia te integrują się z [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), pomagając zespołom identyfikować i łagodzić luki zarówno w kodzie, jak i komponentach łańcucha dostaw AI.

Microsoft również wdraża rozbudowane praktyki bezpieczeństwa łańcucha dostaw wewnętrznie dla wszystkich produktów. Dowiedz się więcej w [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Ugruntowane najlepsze praktyki bezpieczeństwa, które podniosą poziom bezpieczeństwa Twojej implementacji MCP

Każda implementacja MCP dziedziczy istniejący poziom bezpieczeństwa środowiska organizacji, na którym jest oparta, dlatego rozważając bezpieczeństwo MCP jako komponentu Twoich systemów AI, zaleca się podniesienie ogólnego poziomu bezpieczeństwa. Poniższe ugruntowane kontrole bezpieczeństwa są szczególnie istotne:

- Najlepsze praktyki bezpiecznego kodowania w Twojej aplikacji AI – ochrona przed [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 dla LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), używanie bezpiecznych sejfów na sekrety i tokeny, wdrażanie end-to-end bezpiecznej komunikacji między wszystkimi komponentami aplikacji itd.
- Utwardzanie serwera – stosowanie MFA tam, gdzie to możliwe, regularne aktualizacje, integracja serwera z zewnętrznym dostawcą tożsamości dla kontroli dostępu itd.
- Utrzymywanie urządzeń, infrastruktury i aplikacji na bieżąco z aktualizacjami
- Monitorowanie bezpieczeństwa – wdrażanie logowania i monitoringu aplikacji AI (w tym klientów/serwerów MCP) oraz przesyłanie logów do centralnego SIEM w celu wykrywania anomalii
- Architektura zero trust – izolowanie komponentów za pomocą kontroli sieciowych i tożsamościowych w sposób logiczny, aby zminimalizować ruch boczny w przypadku kompromitacji aplikacji AI.

# Kluczowe wnioski

- Fundamenty bezpieczeństwa pozostają kluczowe: bezpieczne kodowanie, zasada najmniejszych uprawnień, weryfikacja łańcucha dostaw i ciągły monitoring są niezbędne dla MCP i obciążeń AI.
- MCP wprowadza nowe ryzyka — takie jak wstrzyknięcie poleceń, zatrucie narzędzi, przejęcie sesji, problem confused deputy, luki w przekazywaniu tokenów i nadmierne uprawnienia — które wymagają zarówno tradycyjnych, jak i specyficznych dla AI środków kontroli.
- Stosuj solidne praktyki uwierzytelniania, autoryzacji i zarządzania tokenami, korzystając tam, gdzie to możliwe, z zewnętrznych dostawców tożsamości, takich jak Microsoft Entra ID.
- Chroń się przed pośrednim wstrzyknięciem poleceń i zatruciem narzędzi, weryfikując metadane narzędzi, monitorując dynamiczne zmiany i stosując rozwiązania takie jak Microsoft Prompt Shields.
- Wdrażaj bezpieczne zarządzanie sesjami, używając niedeterministycznych identyfikatorów sesji, wiążąc sesje z tożsamościami użytkowników i nigdy nie używając sesji do uwierzytelniania.
- Zapobiegaj atakom confused deputy, wymagając wyraźnej zgody użytkownika dla każdego dynamicznie zarejestrowanego klienta oraz stosując odpowiednie praktyki bezpieczeństwa OAuth.
- Unikaj luk w przekazywaniu tokenów, zapewniając, że serwery MCP akceptują tylko tokeny wyraźnie dla nich wydane i odpowiednio weryfikują roszczenia tokenów.
- Traktuj wszystkie komponenty w łańcuchu dostaw AI — w tym modele, embeddingi i dostawców kontekstu — z taką samą starannością jak zależności kodu.
- Bądź na bieżąco z ewoluującymi specyfikacjami MCP i angażuj się w społeczność, aby pomagać kształtować bezpieczne standardy.

# Dodatkowe zasoby

## Zasoby zewnętrzne
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Dodatkowe dokumenty dotyczące bezpieczeństwa

Aby uzyskać bardziej szczegółowe wskazówki dotyczące bezpieczeństwa, zapoznaj się z następującymi dokumentami:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Kompleksowa lista najlepszych praktyk bezpieczeństwa dla implementacji MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Przykłady implementacji integracji Azure Content Safety z serwerami MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Najnowsze kontrole i techniki bezpieczeństwa dla zabezpieczania wdrożeń MCP
- [MCP Best Practices](./mcp-best-practices.md) - Szybki przewodnik po najlepszych praktykach MCP

### Następny krok

Następny: [Rozdział 3: Pierwsze kroki](../03-GettingStarted/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.