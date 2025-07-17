<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:40:03+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "hr"
}
-->
# Najnovije sigurnosne kontrole MCP-a - ažuriranje za srpanj 2025.

Kako se Model Context Protocol (MCP) nastavlja razvijati, sigurnost ostaje ključni faktor. Ovaj dokument prikazuje najnovije sigurnosne kontrole i najbolje prakse za sigurno implementiranje MCP-a zaključno sa srpnjem 2025.

## Autentikacija i autorizacija

### Podrška za OAuth 2.0 delegaciju

Nedavna ažuriranja MCP specifikacije sada omogućuju MCP serverima da delegiraju autentikaciju korisnika vanjskim servisima poput Microsoft Entra ID-a. Ovo značajno poboljšava sigurnosni položaj jer:

1. **Uklanja potrebu za vlastitom implementacijom autentikacije**: Smanjuje rizik od sigurnosnih propusta u prilagođenom kodu za autentikaciju  
2. **Iskorištava etablirane pružatelje identiteta**: Koristi sigurnosne značajke na razini poduzeća  
3. **Centralizira upravljanje identitetima**: Pojednostavljuje upravljanje životnim ciklusom korisnika i kontrolu pristupa  

## Sprječavanje prosljeđivanja tokena

MCP Authorization Specification izričito zabranjuje prosljeđivanje tokena kako bi se spriječilo zaobilaženje sigurnosnih kontrola i problemi s odgovornošću.

### Ključni zahtjevi

1. **MCP serveri NE SMIJU prihvaćati tokene koji nisu izdani za njih**: Potvrdite da svi tokeni imaju ispravan audience claim  
2. **Implementirajte pravilnu validaciju tokena**: Provjerite issuer, audience, isteka i potpis  
3. **Koristite izdavanje zasebnih tokena**: Izdajte nove tokene za downstream servise umjesto prosljeđivanja postojećih tokena  

## Sigurno upravljanje sesijama

Kako biste spriječili otmicu i fiksaciju sesija, implementirajte sljedeće kontrole:

1. **Koristite sigurne, nedeterminističke ID-e sesija**: Generirane kriptografski sigurnim generatorima slučajnih brojeva  
2. **Povežite sesije s identitetom korisnika**: Kombinirajte ID sesije s informacijama specifičnim za korisnika  
3. **Implementirajte pravilnu rotaciju sesija**: Nakon promjena autentikacije ili eskalacije privilegija  
4. **Postavite odgovarajuće vremenske limite sesija**: Izbalansirajte sigurnost i korisničko iskustvo  

## Izolacija izvršavanja alata

Kako biste spriječili lateralno kretanje i ograničili moguće kompromite:

1. **Izolirajte okruženja za izvršavanje alata**: Koristite kontejnere ili zasebne procese  
2. **Primijenite ograničenja resursa**: Spriječite napade iscrpljivanja resursa  
3. **Implementirajte pristup s najmanjim privilegijama**: Dodijelite samo potrebne dozvole  
4. **Nadzorite obrasce izvršavanja**: Otkrivajte anomalno ponašanje  

## Zaštita definicija alata

Kako biste spriječili trovanje alata:

1. **Validirajte definicije alata prije upotrebe**: Provjerite ima li zlonamjernih uputa ili neprimjerenih obrazaca  
2. **Koristite provjeru integriteta**: Hashirajte ili potpišite definicije alata kako biste otkrili neovlaštene promjene  
3. **Implementirajte nadzor promjena**: Upozoravajte na neočekivane izmjene metapodataka alata  
4. **Koristite verzioniranje definicija alata**: Pratite promjene i omogućite povratak na prethodne verzije ako je potrebno  

Ove kontrole zajedno stvaraju snažan sigurnosni okvir za implementacije MCP-a, rješavajući jedinstvene izazove sustava vođenih umjetnom inteligencijom, uz održavanje čvrstih tradicionalnih sigurnosnih praksi.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.