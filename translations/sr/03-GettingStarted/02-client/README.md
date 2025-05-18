<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:50:16+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sr"
}
-->
# Kreiranje klijenta

Klijenti su prilagođene aplikacije ili skripte koje direktno komuniciraju sa MCP Serverom da bi zatražili resurse, alate i upite. Za razliku od korišćenja alata za inspekciju, koji pruža grafički interfejs za interakciju sa serverom, pisanje sopstvenog klijenta omogućava programske i automatizovane interakcije. Ovo omogućava programerima da integrišu MCP mogućnosti u svoje radne tokove, automatizuju zadatke i grade prilagođena rešenja koja odgovaraju specifičnim potrebama.

## Pregled

Ova lekcija uvodi koncept klijenata unutar ekosistema Model Context Protocol (MCP). Naučićete kako da napišete sopstveni klijent i povežete ga sa MCP Serverom.

## Ciljevi učenja

Na kraju ove lekcije, bićete u mogućnosti da:

- Razumete šta klijent može da uradi.
- Napišete sopstveni klijent.
- Povežete i testirate klijent sa MCP serverom kako biste osigurali da server radi kako se očekuje.

## Šta je potrebno za pisanje klijenta?

Da biste napisali klijent, potrebno je da uradite sledeće:

- **Uvezite odgovarajuće biblioteke**. Koristićete istu biblioteku kao i ranije, samo različite konstrukte.
- **Instancirajte klijenta**. Ovo će uključivati kreiranje instance klijenta i povezivanje sa izabranim transportnim metodom.
- **Odlučite koje resurse da navedete**. Vaš MCP server dolazi sa resursima, alatima i upitima, morate odlučiti koji ćete navesti.
- **Integrisati klijenta u host aplikaciju**. Kada znate mogućnosti servera, potrebno je da ovo integrišete u vašu host aplikaciju tako da ako korisnik unese upit ili drugu komandu, odgovarajuća funkcija servera se pokrene.

Sada kada smo razumeli na visokom nivou šta ćemo raditi, hajde da pogledamo primer.

### Primer klijenta

Pogledajmo ovaj primer klijenta: Trenirani ste na podacima do oktobra 2023.

U prethodnom kodu smo:

- Uvezli biblioteke
- Kreirali instancu klijenta i povezali je koristeći stdio za transport.
- Naveli upite, resurse i alate i pokrenuli ih sve.

I eto ga, klijent koji može da komunicira sa MCP Serverom.

Hajde da odvojimo vreme u sledećem delu vežbi i razložimo svaki deo koda i objasnimo šta se dešava.

## Vežba: Pisanje klijenta

Kao što je rečeno gore, hajde da odvojimo vreme objašnjavajući kod, i slobodno kodirajte zajedno ako želite.

### -1- Uvoz biblioteka

Hajde da uvezemo biblioteke koje su nam potrebne, trebaće nam reference na klijenta i na izabrani transportni protokol, stdio. stdio je protokol za stvari koje treba da se pokreću na vašem lokalnom računaru. SSE je drugi transportni protokol koji ćemo pokazati u budućim poglavljima, ali to je vaša druga opcija. Za sada, nastavimo sa stdio.

Pređimo na instanciranje.

### -2- Instanciranje klijenta i transporta

Trebaće nam da kreiramo instancu transporta i našeg klijenta:

### -3- Navođenje funkcija servera

Sada imamo klijent koji može da se poveže kada se program pokrene. Međutim, zapravo ne navodi svoje funkcije pa hajde da to uradimo sledeće:

Odlično, sada smo uhvatili sve funkcije. Sada je pitanje kada ih koristiti? Pa, ovaj klijent je prilično jednostavan, jednostavan u smislu da ćemo morati eksplicitno pozvati funkcije kada ih želimo. U sledećem poglavlju, kreiraćemo napredniji klijent koji ima pristup sopstvenom velikom jezičkom modelu, LLM. Za sada, hajde da vidimo kako možemo pokrenuti funkcije na serveru:

### -4- Pokretanje funkcija

Da bismo pokrenuli funkcije, moramo osigurati da navedemo tačne argumente i u nekim slučajevima ime onoga što pokušavamo da pokrenemo.

### -5- Pokretanje klijenta

Da biste pokrenuli klijenta, ukucajte sledeću komandu u terminalu:

## Zadaci

U ovom zadatku, koristićete ono što ste naučili o kreiranju klijenta, ali kreirajte sopstveni klijent.

Evo servera koji možete koristiti i koji treba da pozovete putem vašeg klijentskog koda, vidite da li možete dodati više funkcija serveru kako biste ga učinili zanimljivijim.

## Rešenje

[Rešenje](./solution/README.md)

## Ključni zaključci

Ključni zaključci za ovo poglavlje o klijentima su sledeći:

- Mogu se koristiti za otkrivanje i pokretanje funkcija na serveru.
- Mogu pokrenuti server dok se sami pokreću (kao u ovom poglavlju), ali klijenti se takođe mogu povezati sa već pokrenutim serverima.
- Odličan su način za testiranje mogućnosti servera pored alternativa kao što je Inspektor, kako je opisano u prethodnom poglavlju.

## Dodatni resursi

- [Izgradnja klijenata u MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Šta dalje

- Sledeće: [Kreiranje klijenta sa LLM](/03-GettingStarted/03-llm-client/README.md)

**Одричање од одговорности**:  
Овај документ је преведен користећи услугу AI превођења [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква погрешна схватања или тумачења која могу настати услед коришћења овог превода.