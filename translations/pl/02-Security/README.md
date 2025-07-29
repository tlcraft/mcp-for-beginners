<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "14830e7df8352430ce7654b70ad969e1",
  "translation_date": "2025-07-29T01:35:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

[![MCP Security Best Practices](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.pl.png)](https://youtu.be/88No8pw706o)

_(Kliknij obrazek powyżej, aby obejrzeć wideo z tej lekcji)_

Wdrożenie Model Context Protocol (MCP) wprowadza potężne możliwości do aplikacji opartych na sztucznej inteligencji, ale jednocześnie wiąże się z unikalnymi wyzwaniami bezpieczeństwa, które wykraczają poza tradycyjne ryzyka związane z oprogramowaniem. Oprócz znanych zagrożeń, takich jak bezpieczne kodowanie, zasada najmniejszych uprawnień czy bezpieczeństwo łańcucha dostaw, MCP i obciążenia AI są narażone na nowe zagrożenia, takie jak wstrzykiwanie poleceń (prompt injection), zatruwanie narzędzi (tool poisoning), dynamiczne modyfikacje narzędzi, przechwytywanie sesji, ataki confused deputy oraz podatności związane z przekazywaniem tokenów. Jeśli nie zostaną odpowiednio zarządzone, te ryzyka mogą prowadzić do wycieku danych, naruszenia prywatności i niezamierzonego zachowania systemu.

Ta lekcja omawia najistotniejsze zagrożenia bezpieczeństwa związane z MCP, w tym uwierzytelnianie, autoryzację, nadmierne uprawnienia, pośrednie wstrzykiwanie poleceń, bezpieczeństwo sesji, problemy confused deputy, podatności związane z przekazywaniem tokenów oraz podatności łańcucha dostaw. Przedstawia również praktyczne środki zaradcze i najlepsze praktyki, które pozwalają je ograniczyć. Dowiesz się także, jak wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety i GitHub Advanced Security, aby wzmocnić implementację MCP. Dzięki zrozumieniu i zastosowaniu tych środków możesz znacząco zmniejszyć ryzyko naruszenia bezpieczeństwa i zapewnić, że Twoje systemy AI pozostaną solidne i godne zaufania.

# Cele nauki

Po ukończeniu tej lekcji będziesz w stanie:

- Zidentyfikować i wyjaśnić unikalne zagrożenia bezpieczeństwa wprowadzone przez Model Context Protocol (MCP), w tym wstrzykiwanie poleceń, zatruwanie narzędzi, nadmierne uprawnienia, przechwytywanie sesji, problemy confused deputy, podatności związane z przekazywaniem tokenów oraz podatności łańcucha dostaw.
- Opisać i zastosować skuteczne środki zaradcze dla zagrożeń bezpieczeństwa MCP, takie jak solidne uwierzytelnianie, zasada najmniejszych uprawnień, bezpieczne zarządzanie tokenami, kontrola bezpieczeństwa sesji i weryfikacja łańcucha dostaw.
- Zrozumieć i wykorzystać rozwiązania Microsoft, takie jak Prompt Shields, Azure Content Safety i GitHub Advanced Security, aby chronić MCP i obciążenia AI.
- Rozpoznać znaczenie walidacji metadanych narzędzi, monitorowania dynamicznych zmian, obrony przed pośrednimi atakami wstrzykiwania poleceń oraz zapobiegania przechwytywaniu sesji.
- Zintegrować ustalone najlepsze praktyki bezpieczeństwa, takie jak bezpieczne kodowanie, utwardzanie serwerów i architektura zero trust, w implementacji MCP, aby zmniejszyć prawdopodobieństwo i skutki naruszeń bezpieczeństwa.

# Kontrole bezpieczeństwa MCP

Każdy system mający dostęp do ważnych zasobów wiąże się z domyślnymi wyzwaniami bezpieczeństwa. Wyzwania te można zazwyczaj rozwiązać poprzez poprawne zastosowanie podstawowych kontroli i koncepcji bezpieczeństwa. Ponieważ MCP jest nowo zdefiniowanym protokołem, jego specyfikacja zmienia się bardzo szybko, a wraz z ewolucją protokołu dojrzewają również kontrole bezpieczeństwa, co umożliwia lepszą integrację z architekturami bezpieczeństwa przedsiębiorstw i ustalonymi najlepszymi praktykami.

Badania opublikowane w [Microsoft Digital Defense Report](https://aka.ms/mddr) wskazują, że 98% zgłoszonych naruszeń można by zapobiec dzięki solidnej higienie bezpieczeństwa. Najlepszą ochroną przed jakimkolwiek naruszeniem jest zadbanie o podstawową higienę bezpieczeństwa, najlepsze praktyki w zakresie bezpiecznego kodowania oraz bezpieczeństwo łańcucha dostaw — te sprawdzone praktyki wciąż mają największy wpływ na zmniejszenie ryzyka bezpieczeństwa.

Przyjrzyjmy się niektórym sposobom, w jakie można zacząć rozwiązywać problemy bezpieczeństwa przy wdrażaniu MCP.

> **Note:** Poniższe informacje są aktualne na dzień **29 maja 2025 roku**. Protokół MCP jest stale rozwijany, a przyszłe implementacje mogą wprowadzać nowe wzorce uwierzytelniania i kontrole. Aby uzyskać najnowsze aktualizacje i wskazówki, zawsze odwołuj się do [MCP Specification](https://spec.modelcontextprotocol.io/) oraz oficjalnego [repozytorium MCP na GitHubie](https://github.com/modelcontextprotocol) i [strony najlepszych praktyk bezpieczeństwa](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problemu
Pierwotna specyfikacja MCP zakładała, że deweloperzy będą pisać własny serwer uwierzytelniania. Wymagało to znajomości OAuth i powiązanych ograniczeń bezpieczeństwa. Serwery MCP działały jako serwery autoryzacji OAuth 2.0, zarządzając wymaganą autoryzacją użytkownika bezpośrednio, zamiast delegować ją do zewnętrznej usługi, takiej jak Microsoft Entra ID. Od **26 kwietnia 2025 roku** aktualizacja specyfikacji MCP pozwala serwerom MCP delegować uwierzytelnianie użytkownika do zewnętrznej usługi.

### Ryzyka
- Błędnie skonfigurowana logika autoryzacji na serwerze MCP może prowadzić do ujawnienia wrażliwych danych i nieprawidłowego stosowania kontroli dostępu.
- Kradzież tokenów OAuth na lokalnym serwerze MCP. Jeśli token zostanie skradziony, może być użyty do podszywania się pod serwer MCP i uzyskania dostępu do zasobów i danych usługi, dla której token OAuth został wydany.

#### Przekazywanie tokenów
Przekazywanie tokenów jest wyraźnie zabronione w specyfikacji autoryzacji, ponieważ wprowadza szereg zagrożeń bezpieczeństwa, w tym:

#### Omijanie kontroli bezpieczeństwa
Serwer MCP lub API downstream mogą implementować ważne kontrole bezpieczeństwa, takie jak ograniczanie liczby żądań, walidacja żądań czy monitorowanie ruchu, które zależą od odbiorcy tokena lub innych ograniczeń poświadczeń. Jeśli klienci mogą uzyskać i używać tokenów bezpośrednio z API downstream, omijając serwer MCP, te kontrole mogą zostać pominięte.

#### Problemy z odpowiedzialnością i ścieżką audytu
Serwer MCP nie będzie w stanie zidentyfikować ani odróżnić klientów MCP, gdy klienci korzystają z tokenów dostępu wydanych upstream, które mogą być nieczytelne dla serwera MCP.  
Logi serwera downstream mogą pokazywać żądania, które wydają się pochodzić z innego źródła o innej tożsamości, zamiast z serwera MCP, który faktycznie przekazuje tokeny.  
Oba te czynniki utrudniają dochodzenie incydentów, kontrole i audyt.  
Jeśli serwer MCP przekazuje tokeny bez walidacji ich roszczeń (np. ról, uprawnień czy odbiorcy) lub innych metadanych, złośliwy aktor posiadający skradziony token może użyć serwera jako proxy do wycieku danych.

#### Problemy z granicami zaufania
Serwer downstream udziela zaufania określonym podmiotom. To zaufanie może obejmować założenia dotyczące pochodzenia lub wzorców zachowań klientów. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów.  
Jeśli token jest akceptowany przez wiele usług bez odpowiedniej walidacji, atakujący, który skompromituje jedną usługę, może użyć tokena do uzyskania dostępu do innych połączonych usług.

#### Ryzyko zgodności w przyszłości
Nawet jeśli serwer MCP zaczyna jako "czyste proxy", może w przyszłości wymagać dodania kontroli bezpieczeństwa. Rozpoczęcie od odpowiedniego rozdzielenia odbiorców tokenów ułatwia ewolucję modelu bezpieczeństwa.

### Środki zaradcze

**Serwery MCP NIE MOGĄ akceptować żadnych tokenów, które nie zostały wyraźnie wydane dla serwera MCP**

- **Przegląd i wzmocnienie logiki autoryzacji:** Dokładnie przeanalizuj implementację autoryzacji na swoim serwerze MCP, aby upewnić się, że tylko zamierzeni użytkownicy i klienci mają dostęp do wrażliwych zasobów. Praktyczne wskazówki znajdziesz w [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) oraz [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Wymuszanie bezpiecznych praktyk dotyczących tokenów:** Postępuj zgodnie z [najlepszymi praktykami Microsoft dotyczącymi walidacji tokenów i ich czasu życia](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby zapobiec nadużyciom tokenów dostępu i zmniejszyć ryzyko ich powtórnego użycia lub kradzieży.
- **Ochrona przechowywania tokenów:** Zawsze przechowuj tokeny w sposób bezpieczny i używaj szyfrowania, aby chronić je w stanie spoczynku i w trakcie przesyłania. Wskazówki dotyczące implementacji znajdziesz w [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).
![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pl.png)

# Problem z zagubionym pełnomocnikiem

### Opis problemu

Problem zagubionego pełnomocnika to luka w zabezpieczeniach, która występuje, gdy serwer MCP działa jako pośrednik między klientami MCP a zewnętrznymi interfejsami API. Luka ta może zostać wykorzystana, gdy serwer MCP używa statycznego identyfikatora klienta do uwierzytelniania w zewnętrznym serwerze autoryzacyjnym, który nie obsługuje dynamicznej rejestracji klientów.

### Ryzyka

- **Obejście zgody opartej na ciasteczkach**: Jeśli użytkownik wcześniej uwierzytelnił się za pośrednictwem serwera proxy MCP, zewnętrzny serwer autoryzacyjny może ustawić ciasteczko zgody w przeglądarce użytkownika. Atakujący może później wykorzystać to, wysyłając użytkownikowi złośliwy link z odpowiednio spreparowanym żądaniem autoryzacji zawierającym złośliwy URI przekierowania.
- **Kradzież kodu autoryzacyjnego**: Gdy użytkownik kliknie złośliwy link, zewnętrzny serwer autoryzacyjny może pominąć ekran zgody z powodu istniejącego ciasteczka, a kod autoryzacyjny może zostać przekierowany na serwer atakującego.
- **Nieautoryzowany dostęp do API**: Atakujący może wymienić skradziony kod autoryzacyjny na tokeny dostępu i podszywać się pod użytkownika, uzyskując dostęp do zewnętrznego API bez wyraźnej zgody.

### Środki zaradcze

- **Wymóg wyraźnej zgody**: Serwery proxy MCP używające statycznych identyfikatorów klientów **MUSZĄ** uzyskać zgodę użytkownika dla każdego dynamicznie zarejestrowanego klienta przed przekazaniem żądania do zewnętrznych serwerów autoryzacyjnych.
- **Prawidłowa implementacja OAuth**: Należy stosować najlepsze praktyki bezpieczeństwa OAuth 2.1, w tym używanie wyzwań kodowych (PKCE) w żądaniach autoryzacyjnych, aby zapobiec przechwyceniu.
- **Walidacja klientów**: Wdrożenie ścisłej walidacji URI przekierowań i identyfikatorów klientów, aby zapobiec wykorzystaniu przez złośliwe podmioty.

# Luki w przekazywaniu tokenów

### Opis problemu

"Przekazywanie tokenów" to antywzorzec, w którym serwer MCP akceptuje tokeny od klienta MCP bez weryfikacji, czy tokeny zostały prawidłowo wydane dla samego serwera MCP, a następnie "przekazuje je" do dalszych interfejsów API. Praktyka ta wyraźnie narusza specyfikację autoryzacji MCP i wprowadza poważne zagrożenia bezpieczeństwa.

### Ryzyka

- **Obejście mechanizmów bezpieczeństwa**: Klienci mogą ominąć ważne mechanizmy bezpieczeństwa, takie jak ograniczanie liczby żądań, walidacja żądań czy monitorowanie ruchu, jeśli mogą używać tokenów bezpośrednio z dalszymi interfejsami API bez odpowiedniej weryfikacji.
- **Problemy z odpowiedzialnością i śledzeniem**: Serwer MCP nie będzie w stanie zidentyfikować ani rozróżnić klientów MCP, gdy ci używają tokenów dostępu wydanych przez inne podmioty, co utrudnia dochodzenie w sprawie incydentów i audyt.
- **Eksfiltracja danych**: Jeśli tokeny są przekazywane bez odpowiedniej walidacji roszczeń, złośliwy podmiot posiadający skradziony token może użyć serwera jako proxy do eksfiltracji danych.
- **Naruszenie granic zaufania**: Zasoby serwerów mogą ufać określonym podmiotom, zakładając ich pochodzenie lub wzorce zachowań. Naruszenie tej granicy zaufania może prowadzić do nieoczekiwanych problemów z bezpieczeństwem.
- **Niewłaściwe wykorzystanie tokenów w wielu usługach**: Jeśli tokeny są akceptowane przez wiele usług bez odpowiedniej walidacji, atakujący, który skompromituje jedną usługę, może użyć tokenu do uzyskania dostępu do innych połączonych usług.

### Środki zaradcze

- **Walidacja tokenów**: Serwery MCP **NIE MOGĄ** akceptować żadnych tokenów, które nie zostały wyraźnie wydane dla samego serwera MCP.
- **Weryfikacja odbiorcy**: Zawsze weryfikuj, czy tokeny mają odpowiednie roszczenie odbiorcy, które odpowiada tożsamości serwera MCP.
- **Prawidłowe zarządzanie cyklem życia tokenów**: Wdrożenie tokenów dostępu o krótkim czasie życia oraz odpowiednich praktyk rotacji tokenów, aby zmniejszyć ryzyko ich kradzieży i niewłaściwego wykorzystania.

# Przejęcie sesji

### Opis problemu

Przejęcie sesji to wektor ataku, w którym klient otrzymuje identyfikator sesji od serwera, a nieautoryzowana osoba uzyskuje i używa tego samego identyfikatora sesji, aby podszywać się pod oryginalnego klienta i wykonywać nieautoryzowane działania w jego imieniu. Jest to szczególnie niepokojące w przypadku stanowych serwerów HTTP obsługujących żądania MCP.

### Ryzyka

- **Wstrzyknięcie złośliwego żądania w przejętej sesji**: Atakujący, który uzyska identyfikator sesji, może wysyłać złośliwe zdarzenia do serwera, który współdzieli stan sesji z serwerem, z którym połączony jest klient, potencjalnie wywołując szkodliwe działania lub uzyskując dostęp do poufnych danych.
- **Podszywanie się w przejętej sesji**: Atakujący ze skradzionym identyfikatorem sesji może wykonywać żądania bezpośrednio do serwera MCP, omijając uwierzytelnianie i będąc traktowanym jako prawowity użytkownik.
- **Kompromitacja wznawialnych strumieni**: Gdy serwer obsługuje ponowne dostarczanie/wznawialne strumienie, atakujący może przedwcześnie zakończyć żądanie, co prowadzi do jego wznowienia przez oryginalnego klienta z potencjalnie złośliwą zawartością.

### Środki zaradcze

- **Weryfikacja autoryzacji**: Serwery MCP implementujące autoryzację **MUSZĄ** weryfikować wszystkie przychodzące żądania i **NIE MOGĄ** używać sesji do uwierzytelniania.
- **Bezpieczne identyfikatory sesji**: Serwery MCP **MUSZĄ** używać bezpiecznych, niedeterministycznych identyfikatorów sesji generowanych za pomocą bezpiecznych generatorów liczb losowych. Unikaj przewidywalnych lub sekwencyjnych identyfikatorów.
- **Powiązanie sesji z użytkownikiem**: Serwery MCP **POWINNY** powiązać identyfikatory sesji z informacjami specyficznymi dla użytkownika, łącząc identyfikator sesji z unikalnymi danymi autoryzowanego użytkownika (np. wewnętrznym identyfikatorem użytkownika) w formacie `<user_id>:<session_id>`.
- **Wygasanie sesji**: Wdrożenie odpowiedniego wygasania i rotacji sesji, aby ograniczyć okno podatności w przypadku kompromitacji identyfikatora sesji.
- **Bezpieczeństwo transportu**: Zawsze używaj HTTPS do całej komunikacji, aby zapobiec przechwyceniu identyfikatora sesji.

# Bezpieczeństwo łańcucha dostaw

Bezpieczeństwo łańcucha dostaw pozostaje kluczowe w erze AI, ale zakres tego, co stanowi łańcuch dostaw, znacznie się rozszerzył. Oprócz tradycyjnych pakietów kodu, należy teraz rygorystycznie weryfikować i monitorować wszystkie komponenty związane z AI, w tym modele bazowe, usługi osadzania, dostawców kontekstu i zewnętrzne interfejsy API. Każdy z tych elementów może wprowadzać luki lub ryzyka, jeśli nie zostanie odpowiednio zarządzony.

**Kluczowe praktyki bezpieczeństwa łańcucha dostaw dla AI i MCP:**
- **Weryfikacja wszystkich komponentów przed integracją**: Dotyczy to nie tylko bibliotek open-source, ale także modeli AI, źródeł danych i zewnętrznych interfejsów API. Zawsze sprawdzaj pochodzenie, licencje i znane luki.
- **Utrzymanie bezpiecznych procesów wdrażania**: Używaj zautomatyzowanych potoków CI/CD z wbudowanym skanowaniem bezpieczeństwa, aby wykrywać problemy na wczesnym etapie. Upewnij się, że do produkcji trafiają tylko zaufane artefakty.
- **Ciągłe monitorowanie i audyt**: Wdrożenie ciągłego monitorowania wszystkich zależności, w tym modeli i usług danych, w celu wykrywania nowych luk lub ataków na łańcuch dostaw.
- **Zasada najmniejszych uprawnień i kontrola dostępu**: Ogranicz dostęp do modeli, danych i usług tylko do tego, co jest niezbędne do działania serwera MCP.
- **Szybka reakcja na zagrożenia**: Miej przygotowany proces łatania lub wymiany skompromitowanych komponentów oraz rotacji tajemnic lub poświadczeń w przypadku wykrycia naruszenia.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferuje funkcje takie jak skanowanie tajemnic, skanowanie zależności i analiza CodeQL. Narzędzia te integrują się z [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), pomagając zespołom identyfikować i łagodzić luki w zabezpieczeniach zarówno w kodzie, jak i komponentach łańcucha dostaw AI.

Microsoft wdraża również rozbudowane praktyki bezpieczeństwa łańcucha dostaw wewnętrznie dla wszystkich produktów. Dowiedz się więcej w [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Ugruntowane najlepsze praktyki bezpieczeństwa, które poprawią bezpieczeństwo Twojej implementacji MCP

Każda implementacja MCP dziedziczy istniejący poziom bezpieczeństwa środowiska organizacji, na którym jest oparta. Dlatego, rozważając bezpieczeństwo MCP jako elementu ogólnych systemów AI, zaleca się poprawę ogólnego poziomu bezpieczeństwa. Szczególnie istotne są następujące ugruntowane mechanizmy bezpieczeństwa:

- Najlepsze praktyki bezpiecznego kodowania w aplikacjach AI – ochrona przed [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 dla LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), użycie bezpiecznych skarbców do przechowywania tajemnic i tokenów, wdrożenie szyfrowanej komunikacji end-to-end między wszystkimi komponentami aplikacji itp.
- Utwardzanie serwerów – stosowanie MFA, regularne aktualizacje, integracja serwera z zewnętrznym dostawcą tożsamości w celu kontroli dostępu itp.
- Aktualizowanie urządzeń, infrastruktury i aplikacji za pomocą poprawek
- Monitorowanie bezpieczeństwa – wdrożenie logowania i monitorowania aplikacji AI (w tym klientów/serwerów MCP) oraz przesyłanie tych logów do centralnego systemu SIEM w celu wykrywania anomalii
- Architektura zero trust – izolowanie komponentów za pomocą kontroli sieciowych i tożsamościowych w sposób logiczny, aby zminimalizować ruch lateralny w przypadku kompromitacji aplikacji AI.

# Kluczowe wnioski

- Podstawy bezpieczeństwa pozostają kluczowe: Bezpieczne kodowanie, zasada najmniejszych uprawnień, weryfikacja łańcucha dostaw i ciągłe monitorowanie są niezbędne dla obciążeń MCP i AI.
- MCP wprowadza nowe ryzyka – takie jak wstrzyknięcie poleceń, zatruwanie narzędzi, przejęcie sesji, problem zagubionego pełnomocnika, luki w przekazywaniu tokenów i nadmierne uprawnienia – które wymagają zarówno tradycyjnych, jak i specyficznych dla AI mechanizmów kontroli.
- Stosuj solidne praktyki uwierzytelniania, autoryzacji i zarządzania tokenami, korzystając z zewnętrznych dostawców tożsamości, takich jak Microsoft Entra ID, gdzie to możliwe.
- Chroń przed pośrednim wstrzyknięciem poleceń i zatruwaniem narzędzi, weryfikując metadane narzędzi, monitorując dynamiczne zmiany i korzystając z rozwiązań takich jak Microsoft Prompt Shields.
- Wdrożenie bezpiecznego zarządzania sesjami poprzez użycie niedeterministycznych identyfikatorów sesji, powiązanie sesji z tożsamościami użytkowników i unikanie używania sesji do uwierzytelniania.
- Zapobieganie atakom zagubionego pełnomocnika poprzez wymaganie wyraźnej zgody użytkownika dla każdego dynamicznie zarejestrowanego klienta i wdrożenie odpowiednich praktyk bezpieczeństwa OAuth.
- Unikaj luk w przekazywaniu tokenów, upewniając się, że serwery MCP akceptują tylko tokeny wyraźnie wydane dla nich i odpowiednio weryfikują roszczenia tokenów.
- Traktuj wszystkie komponenty w łańcuchu dostaw AI – w tym modele, osadzenia i dostawców kontekstu – z taką samą rygorystycznością jak zależności kodu.
- Bądź na bieżąco z ewoluującymi specyfikacjami MCP i przyczyniaj się do społeczności, aby pomóc w kształtowaniu bezpiecznych standardów.

# Dodatkowe zasoby

## Zasoby zewnętrzne
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [Specyfikacja MCP](https://spec.modelcontextprotocol.io/)
- [Najlepsze praktyki bezpieczeństwa MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Specyfikacja autoryzacji MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Najlepsze praktyki bezpieczeństwa OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Wstrzyknięcie poleceń w MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Ataki zatruwania narzędzi (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls w MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Dokumentacja Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 dla LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Bezpieczny dostęp o najmniejszych uprawnieniach (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepsze praktyki walidacji tokenów i ich żywotności](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Bezpieczne przechowywanie tokenów i ich szyfrowanie (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management jako brama uwierzytelniania dla MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Używanie Microsoft Entra ID do uwierzytelniania z serwerami MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Dodatkowe dokumenty dotyczące bezpieczeństwa

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za wiarygodne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.