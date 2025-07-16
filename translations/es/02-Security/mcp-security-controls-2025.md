<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-16T23:06:09+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "es"
}
-->
# Últimas Controles de Seguridad MCP - Actualización de julio de 2025

A medida que el Protocolo de Contexto de Modelo (MCP) sigue evolucionando, la seguridad continúa siendo una consideración fundamental. Este documento describe los controles de seguridad más recientes y las mejores prácticas para implementar MCP de forma segura a partir de julio de 2025.

## Autenticación y Autorización

### Soporte de Delegación OAuth 2.0

Las actualizaciones recientes a la especificación MCP ahora permiten que los servidores MCP deleguen la autenticación de usuarios a servicios externos como Microsoft Entra ID. Esto mejora significativamente la postura de seguridad al:

1. **Eliminar la implementación personalizada de autenticación**: Reduce el riesgo de fallos de seguridad en el código de autenticación personalizado  
2. **Aprovechar proveedores de identidad consolidados**: Se beneficia de características de seguridad a nivel empresarial  
3. **Centralizar la gestión de identidades**: Simplifica la gestión del ciclo de vida del usuario y el control de acceso  


## Prevención de Passthrough de Tokens

La Especificación de Autorización MCP prohíbe explícitamente el passthrough de tokens para evitar la evasión de controles de seguridad y problemas de responsabilidad.

### Requisitos clave

1. **Los servidores MCP NO DEBEN aceptar tokens que no hayan sido emitidos para ellos**: Validar que todos los tokens tengan el claim de audiencia correcto  
2. **Implementar una validación adecuada de tokens**: Verificar emisor, audiencia, expiración y firma  
3. **Usar emisión de tokens separada**: Emitir nuevos tokens para servicios descendentes en lugar de pasar tokens existentes  

## Gestión Segura de Sesiones

Para prevenir secuestro y fijación de sesiones, implemente los siguientes controles:

1. **Usar IDs de sesión seguros y no deterministas**: Generados con generadores de números aleatorios criptográficamente seguros  
2. **Vincular sesiones a la identidad del usuario**: Combinar IDs de sesión con información específica del usuario  
3. **Implementar rotación adecuada de sesiones**: Después de cambios en la autenticación o escalamiento de privilegios  
4. **Establecer tiempos de expiración apropiados para sesiones**: Equilibrar seguridad con experiencia de usuario  


## Aislamiento de Ejecución de Herramientas

Para prevenir movimientos laterales y contener posibles compromisos:

1. **Aislar los entornos de ejecución de herramientas**: Usar contenedores o procesos separados  
2. **Aplicar límites de recursos**: Prevenir ataques de agotamiento de recursos  
3. **Implementar acceso con privilegios mínimos**: Conceder solo los permisos necesarios  
4. **Monitorear patrones de ejecución**: Detectar comportamientos anómalos  

## Protección de Definiciones de Herramientas

Para evitar la contaminación de herramientas:

1. **Validar definiciones de herramientas antes de usarlas**: Revisar instrucciones maliciosas o patrones inapropiados  
2. **Usar verificación de integridad**: Hashear o firmar definiciones de herramientas para detectar cambios no autorizados  
3. **Implementar monitoreo de cambios**: Alertar sobre modificaciones inesperadas en los metadatos de las herramientas  
4. **Control de versiones de definiciones de herramientas**: Rastrear cambios y permitir revertir si es necesario  

Estos controles trabajan en conjunto para crear una postura de seguridad robusta para las implementaciones MCP, abordando los desafíos únicos de los sistemas impulsados por IA mientras mantienen prácticas tradicionales de seguridad sólidas.

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.