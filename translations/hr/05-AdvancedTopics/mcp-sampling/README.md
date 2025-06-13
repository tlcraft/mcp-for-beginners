<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-06-13T01:22:00+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "hr"
}
-->
## Determinističko uzorkovanje

Za aplikacije koje zahtijevaju konzistentne rezultate, determinističko uzorkovanje osigurava ponovljive ishode. To postiže korištenjem fiksnog nasumičnog sjemena i postavljanjem temperature na nulu.

Pogledajmo donji primjer implementacije koji pokazuje determinističko uzorkovanje u različitim programskim jezicima.

## Dinamička konfiguracija uzorkovanja

Inteligentno uzorkovanje prilagođava parametre na temelju konteksta i zahtjeva svakog zahtjeva. To znači dinamičko podešavanje parametara poput temperature, top_p i kazni ovisno o vrsti zadatka, preferencijama korisnika ili povijesnoj izvedbi.

Pogledajmo kako implementirati dinamičko uzorkovanje u različitim programskim jezicima.

## Što slijedi

- [5.7 Skaliranje](../mcp-scaling/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakva nesporazuma ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.