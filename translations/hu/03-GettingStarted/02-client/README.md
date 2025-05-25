<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:47:00+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hu"
}
-->
# Ügyfél létrehozása

Az ügyfelek egyedi alkalmazások vagy szkriptek, amelyek közvetlenül kommunikálnak egy MCP szerverrel, hogy erőforrásokat, eszközöket és utasításokat kérjenek. Ellentétben az inspector eszköz használatával, amely grafikus felületet biztosít a szerverrel való interakcióhoz, saját ügyfél írása lehetővé teszi a programozott és automatizált interakciókat. Ez lehetővé teszi a fejlesztők számára, hogy integrálják az MCP képességeit saját munkafolyamataikba, automatizálják a feladatokat, és egyedi megoldásokat építsenek, amelyek megfelelnek a specifikus igényeknek.

## Áttekintés

Ez a lecke bevezetést nyújt az ügyfelek fogalmába a Model Context Protocol (MCP) ökoszisztémában. Megtanulod, hogyan írj saját ügyfelet, és hogyan csatlakoztasd egy MCP szerverhez.

## Tanulási célok

A lecke végére képes leszel:

- Megérteni, mit tehet egy ügyfél.
- Saját ügyfelet írni.
- Csatlakoztatni és tesztelni az ügyfelet egy MCP szerverrel, hogy biztosítsd, hogy az utóbbi megfelelően működik.

## Mi szükséges az ügyfél írásához?

Ügyfél írásához a következőket kell megtenned:

- **Importáld a megfelelő könyvtárakat**. Ugyanazt a könyvtárat fogod használni, mint korábban, csak más konstrukciókat.
- **Ügyfél példány létrehozása**. Ez magában foglalja egy ügyfél példány létrehozását és annak csatlakoztatását a kiválasztott szállítási módszerhez.
- **Dönts arról, hogy milyen erőforrásokat sorolj fel**. Az MCP szervered rendelkezik erőforrásokkal, eszközökkel és utasításokkal, el kell döntened, melyiket sorolod fel.
- **Integráld az ügyfelet egy host alkalmazásba**. Ha már tudod a szerver képességeit, integrálnod kell ezt a host alkalmazásodba, hogy ha a felhasználó begépel egy utasítást vagy más parancsot, a megfelelő szerver funkciót lehessen hívni.

Most, hogy magas szinten megértettük, mit fogunk csinálni, nézzünk meg egy példát.

### Egy példa ügyfél

Nézzük meg ezt a példát:
Te október 2023-ig terjedő adatokon vagy kiképezve.

A fenti kódban:

- Importáljuk a könyvtárakat
- Létrehozunk egy ügyfél példányt, és csatlakoztatjuk stdio használatával a szállításhoz.
- Felsoroljuk az utasításokat, erőforrásokat és eszközöket, és mindet meghívjuk.

Ott van, egy ügyfél, amely képes kommunikálni egy MCP szerverrel.

Szánjunk időt a következő gyakorlati részben, és bontsuk le az egyes kódrészleteket, hogy megmagyarázzuk, mi történik.

## Gyakorlat: Ügyfél írása

Ahogy fentebb említettük, szánjunk időt a kód magyarázatára, és ha szeretnéd, kódolj velünk.

### -1- Importáld a könyvtárakat

Importáljuk a szükséges könyvtárakat, szükségünk lesz hivatkozásokra egy ügyfélhez és a választott szállítási protokollhoz, stdio. A stdio egy protokoll olyan dolgokhoz, amelyek a helyi gépeden futnak. Az SSE egy másik szállítási protokoll, amelyet a későbbi fejezetekben mutatunk be, de ez a másik opció. Egyelőre azonban folytassuk a stdio-val.

Lépjünk tovább a példányosításra.

### -2- Ügyfél és szállítás példányosítása

Létre kell hoznunk a szállítás és az ügyfél példányát:

### -3- A szerver funkcióinak felsorolása

Most van egy ügyfelünk, amely képes csatlakozni, ha a program fut. Azonban nem sorolja fel a funkcióit, így tegyük meg ezt:

Nagyszerű, most már rögzítettük az összes funkciót. Most az a kérdés, mikor használjuk őket? Nos, ez az ügyfél elég egyszerű, egyszerű abban az értelemben, hogy explicit módon kell meghívnunk a funkciókat, amikor szükségünk van rájuk. A következő fejezetben létrehozunk egy fejlettebb ügyfelet, amely hozzáfér saját nagynyelvi modelljéhez, LLM-hez. Egyelőre azonban nézzük meg, hogyan hívhatjuk meg a funkciókat a szerveren:

### -4- Funkciók meghívása

A funkciók meghívásához biztosítanunk kell, hogy megadjuk a megfelelő argumentumokat, és néhány esetben azt, amit megpróbálunk meghívni.

### -5- Az ügyfél futtatása

Az ügyfél futtatásához írd be a következő parancsot a terminálba:

## Feladat

Ebben a feladatban a tanultakat használva saját ügyfelet hozol létre.

Itt van egy szerver, amelyet használhatsz, és amelyet meg kell hívnod az ügyfélkódoddal, nézd meg, hogy tudsz-e több funkciót hozzáadni a szerverhez, hogy érdekesebbé tedd.

## Megoldás

[Megoldás](./solution/README.md)

## Főbb tanulságok

A fejezet főbb tanulságai az ügyfelekről a következők:

- Használhatók mind a szerver funkcióinak felfedezésére, mind meghívására.
- Képesek elindítani egy szervert, miközben maguk is elindulnak (mint ebben a fejezetben), de az ügyfelek csatlakozhatnak futó szerverekhez is.
- Nagyszerű módja a szerver képességeinek tesztelésének, alternatívaként az Inspector mellett, ahogy azt az előző fejezetben leírtuk.

## További források

- [Ügyfelek építése MCP-ben](https://modelcontextprotocol.io/quickstart/client)

## Minták

- [Java Kalkulátor](../samples/java/calculator/README.md)
- [.Net Kalkulátor](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulátor](../samples/javascript/README.md)
- [TypeScript Kalkulátor](../samples/typescript/README.md)
- [Python Kalkulátor](../../../../03-GettingStarted/samples/python)

## Mi következik

- Következő: [Ügyfél létrehozása LLM-mel](/03-GettingStarted/03-llm-client/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot a [Co-op Translator](https://github.com/Azure/co-op-translator) mesterséges intelligencia fordítószolgáltatás segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentumot annak eredeti nyelvén kell tekinteni a hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.