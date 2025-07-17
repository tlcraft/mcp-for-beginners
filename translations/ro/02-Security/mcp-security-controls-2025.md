<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:39:24+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "ro"
}
-->
# Cele mai recente controale de securitate MCP - Actualizare iulie 2025

Pe măsură ce Model Context Protocol (MCP) continuă să evolueze, securitatea rămâne o preocupare esențială. Acest document prezintă cele mai noi controale de securitate și bune practici pentru implementarea sigură a MCP, valabile începând cu iulie 2025.

## Autentificare și autorizare

### Suport pentru delegarea OAuth 2.0

Actualizările recente ale specificației MCP permit acum serverelor MCP să delege autentificarea utilizatorilor către servicii externe, cum ar fi Microsoft Entra ID. Aceasta îmbunătățește semnificativ postura de securitate prin:

1. **Eliminarea implementărilor personalizate de autentificare**: Reduce riscul apariției vulnerabilităților în codul de autentificare personalizat  
2. **Folosirea furnizorilor de identitate consacrați**: Beneficiază de funcționalități de securitate la nivel enterprise  
3. **Centralizarea managementului identității**: Simplifică gestionarea ciclului de viață al utilizatorilor și controlul accesului  

## Prevenirea trecerii token-urilor

Specificarea MCP Authorization interzice explicit trecerea token-urilor pentru a preveni ocolirea controalelor de securitate și problemele de responsabilitate.

### Cerințe cheie

1. **Serverele MCP NU TREBUIE să accepte token-uri care nu le sunt destinate**: Verificați ca toate token-urile să aibă claim-ul audience corect  
2. **Implementați validarea corectă a token-urilor**: Verificați emițătorul, audiența, expirarea și semnătura  
3. **Folosiți emiterea separată a token-urilor**: Emiteți token-uri noi pentru serviciile downstream în loc să transmiteți token-urile existente  

## Management sigur al sesiunilor

Pentru a preveni atacurile de tip hijacking și fixation asupra sesiunilor, implementați următoarele controale:

1. **Folosiți ID-uri de sesiune sigure și nedeterministe**: Generate cu generatoare criptografic sigure de numere aleatoare  
2. **Asociați sesiunile cu identitatea utilizatorului**: Combinați ID-urile de sesiune cu informații specifice utilizatorului  
3. **Implementați rotația corectă a sesiunilor**: După schimbări de autentificare sau escaladări de privilegii  
4. **Stabiliți timeout-uri adecvate pentru sesiuni**: Echilibrați securitatea cu experiența utilizatorului  

## Izolarea execuției uneltelor

Pentru a preveni mișcarea laterală și a limita compromiterile potențiale:

1. **Izolați mediile de execuție ale uneltelor**: Folosiți containere sau procese separate  
2. **Aplicați limite de resurse**: Preveniți atacurile de epuizare a resurselor  
3. **Implementați acces cu privilegii minime**: Acordați doar permisiunile necesare  
4. **Monitorizați tiparele de execuție**: Detectați comportamente anormale  

## Protecția definițiilor uneltelor

Pentru a preveni intoxicarea uneltelor:

1. **Validați definițiile uneltelor înainte de utilizare**: Verificați instrucțiunile malițioase sau tiparele nepotrivite  
2. **Folosiți verificarea integrității**: Hash-uiți sau semnați definițiile uneltelor pentru a detecta modificările neautorizate  
3. **Implementați monitorizarea modificărilor**: Alertează la modificări neașteptate ale metadatelor uneltelor  
4. **Gestionați versiuni ale definițiilor uneltelor**: Urmăriți modificările și permiteți revenirea la versiuni anterioare dacă este necesar  

Aceste controale funcționează împreună pentru a crea o postură robustă de securitate pentru implementările MCP, abordând provocările unice ale sistemelor AI, menținând în același timp practici tradiționale solide de securitate.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.