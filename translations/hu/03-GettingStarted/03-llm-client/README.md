<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:27:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
# Ügyfél létrehozása LLM-mel

Eddig láthattad, hogyan kell szervert és klienst létrehozni. Az ügyfél képes volt kifejezetten hívni a szervert, hogy felsorolja annak eszközeit, erőforrásait és promptjait. Azonban ez nem túl praktikus megközelítés. A felhasználód az ügynöki korszakban él, és arra számít, hogy természetes nyelvi promptokkal kommunikál egy LLM-mel. A felhasználódnak nem számít, hogy MCP-t használsz-e a képességeid tárolására, de elvárják, hogy természetes nyelven kommunikáljanak. Hogyan oldjuk meg ezt? A megoldás az, hogy egy LLM-et adunk az ügyfélhez.

## Áttekintés

Ebben a leckében arra koncentrálunk, hogy hogyan adjunk hozzá egy LLM-et az ügyfélhez, és bemutatjuk, hogy ez mennyivel jobb élményt nyújt a felhasználónak.

## Tanulási célok

A lecke végére képes leszel:

- Ügyfelet létrehozni LLM-mel.
- Zökkenőmentesen kommunikálni egy MCP szerverrel LLM használatával.
- Jobb felhasználói élményt nyújtani az ügyféloldalon.

## Megközelítés

Próbáljuk megérteni, milyen megközelítést kell alkalmaznunk. Az LLM hozzáadása egyszerűnek hangzik, de valójában hogyan tesszük ezt meg?

Így fog az ügyfél kommunikálni a szerverrel:

1. Kapcsolat létrehozása a szerverrel.

1. Képességek, promptok, erőforrások és eszközök felsorolása, és ezek sémájának mentése.

1. LLM hozzáadása és a mentett képességek és sémáik átadása az LLM által értett formátumban.

1. Felhasználói prompt kezelése úgy, hogy átadjuk azt az LLM-nek az ügyfél által felsorolt eszközökkel együtt.

Nagyszerű, most már értjük, hogyan valósíthatjuk meg ezt magas szinten, próbáljuk ki az alábbi gyakorlatban.

## Gyakorlat: Ügyfél létrehozása LLM-mel

Ebben a gyakorlatban megtanuljuk, hogyan adjunk hozzá egy LLM-et az ügyfélhez.

### -1- Kapcsolódás a szerverhez

Először hozzuk létre az ügyfelünket:
Az adatok 2023 októberéig terjedő részén lettél betanítva.

Nagyszerű, a következő lépésben soroljuk fel a szerver képességeit.

### -2- A szerver képességeinek felsorolása

Most kapcsolódunk a szerverhez és kérjük a képességeit:

### -3- A szerver képességeinek átalakítása LLM eszközökké

A következő lépés a szerver képességeinek felsorolása után, hogy átalakítjuk őket olyan formátumra, amit az LLM megért. Miután ezt megtettük, ezeket a képességeket eszközként biztosíthatjuk az LLM-nek.

Nagyszerű, most már fel vagyunk készülve a felhasználói kérések kezelésére, tehát ezt fogjuk következőként megoldani.

### -4- Felhasználói prompt kérés kezelése

A kód ezen részében fogjuk kezelni a felhasználói kéréseket.

Nagyszerű, sikerült!

## Feladat

Vedd a gyakorlatból származó kódot, és bővítsd ki a szervert további eszközökkel. Ezután hozz létre egy LLM-mel rendelkező ügyfelet, mint a gyakorlatban, és teszteld különböző promptokkal, hogy megbizonyosodj róla, hogy az összes szerver eszköz dinamikusan kerül meghívásra. Az ilyen módon épített ügyfél biztosítja, hogy a végfelhasználó nagyszerű élményt kapjon, mivel képes lesz promptokat használni ahelyett, hogy pontos ügyfélparancsokat kellene használnia, és nem fogja észrevenni, hogy MCP szerver hívásra kerül.

## Megoldás

[Megoldás](/03-GettingStarted/03-llm-client/solution/README.md)

## Fontos tanulságok

- Egy LLM hozzáadása az ügyfélhez jobb módot biztosít a felhasználók számára az MCP szerverekkel való interakcióra.
- Az MCP szerver válaszát olyan formátumra kell konvertálni, amit az LLM megért.

## Minták

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver fogyasztása Visual Studio Code használatával](/03-GettingStarted/04-vscode/README.md)

**Felelősség kizárása**:  
Ezt a dokumentumot az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével fordítottuk le. Bár igyekszünk pontosságra törekedni, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.