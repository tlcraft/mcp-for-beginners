<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-16T23:11:37+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "es"
}
-->
# Mejores Prácticas de Seguridad para MCP - Actualización Julio 2025

## Mejores Prácticas de Seguridad Integrales para Implementaciones MCP

Al trabajar con servidores MCP, sigue estas mejores prácticas de seguridad para proteger tus datos, infraestructura y usuarios:

1. **Validación de Entradas**: Siempre valida y sanitiza las entradas para evitar ataques de inyección y problemas de delegado confundido.
   - Implementa una validación estricta para todos los parámetros de las herramientas
   - Usa validación de esquemas para asegurar que las solicitudes cumplan con los formatos esperados
   - Filtra contenido potencialmente malicioso antes de procesarlo

2. **Control de Acceso**: Implementa autenticación y autorización adecuadas para tu servidor MCP con permisos granulares.
   - Usa OAuth 2.0 con proveedores de identidad establecidos como Microsoft Entra ID
   - Implementa control de acceso basado en roles (RBAC) para las herramientas MCP
   - Nunca implementes autenticación personalizada cuando existen soluciones establecidas

3. **Comunicación Segura**: Usa HTTPS/TLS para todas las comunicaciones con tu servidor MCP y considera añadir cifrado adicional para datos sensibles.
   - Configura TLS 1.3 cuando sea posible
   - Implementa pinning de certificados para conexiones críticas
   - Rota certificados regularmente y verifica su validez

4. **Limitación de Tasa**: Implementa limitación de tasa para prevenir abusos, ataques DoS y gestionar el consumo de recursos.
   - Establece límites de solicitudes apropiados según los patrones de uso esperados
   - Implementa respuestas graduadas ante solicitudes excesivas
   - Considera límites de tasa específicos por usuario según el estado de autenticación

5. **Registro y Monitoreo**: Supervisa tu servidor MCP para detectar actividad sospechosa e implementa auditorías completas.
   - Registra todos los intentos de autenticación y las invocaciones de herramientas
   - Implementa alertas en tiempo real para patrones sospechosos
   - Asegura que los registros se almacenen de forma segura y no puedan ser manipulados

6. **Almacenamiento Seguro**: Protege datos sensibles y credenciales con cifrado adecuado en reposo.
   - Usa bóvedas de claves o almacenes seguros para todos los secretos
   - Implementa cifrado a nivel de campo para datos sensibles
   - Rota regularmente las claves de cifrado y credenciales

7. **Gestión de Tokens**: Prevén vulnerabilidades de paso de tokens validando y sanitizando todas las entradas y salidas del modelo.
   - Implementa validación de tokens basada en claims de audiencia
   - Nunca aceptes tokens que no hayan sido emitidos explícitamente para tu servidor MCP
   - Implementa una gestión adecuada del tiempo de vida y rotación de tokens

8. **Gestión de Sesiones**: Implementa manejo seguro de sesiones para prevenir secuestro y fijación de sesión.
   - Usa IDs de sesión seguros y no determinísticos
   - Vincula las sesiones a información específica del usuario
   - Implementa expiración y rotación adecuada de sesiones

9. **Aislamiento en la Ejecución de Herramientas**: Ejecuta las herramientas en entornos aislados para evitar movimientos laterales en caso de compromiso.
   - Implementa aislamiento mediante contenedores para la ejecución de herramientas
   - Aplica límites de recursos para prevenir ataques de agotamiento
   - Usa contextos de ejecución separados para diferentes dominios de seguridad

10. **Auditorías de Seguridad Regulares**: Realiza revisiones periódicas de seguridad en tus implementaciones MCP y sus dependencias.
    - Programa pruebas de penetración regulares
    - Usa herramientas de escaneo automatizadas para detectar vulnerabilidades
    - Mantén las dependencias actualizadas para abordar problemas de seguridad conocidos

11. **Filtrado de Seguridad de Contenido**: Implementa filtros de seguridad de contenido tanto para entradas como para salidas.
    - Usa Azure Content Safety o servicios similares para detectar contenido dañino
    - Implementa técnicas de protección contra inyección en prompts
    - Escanea el contenido generado para detectar posibles fugas de datos sensibles

12. **Seguridad en la Cadena de Suministro**: Verifica la integridad y autenticidad de todos los componentes en tu cadena de suministro de IA.
    - Usa paquetes firmados y verifica las firmas
    - Implementa análisis de la lista de materiales de software (SBOM)
    - Monitorea actualizaciones maliciosas en las dependencias

13. **Protección de la Definición de Herramientas**: Prevén el envenenamiento de herramientas asegurando las definiciones y metadatos.
    - Valida las definiciones de herramientas antes de usarlas
    - Monitorea cambios inesperados en los metadatos de las herramientas
    - Implementa verificaciones de integridad para las definiciones de herramientas

14. **Monitoreo Dinámico de Ejecución**: Supervisa el comportamiento en tiempo de ejecución de los servidores y herramientas MCP.
    - Implementa análisis de comportamiento para detectar anomalías
    - Configura alertas para patrones de ejecución inesperados
    - Usa técnicas de protección de aplicaciones en tiempo de ejecución (RASP)

15. **Principio de Mínimos Privilegios**: Asegura que los servidores y herramientas MCP operen con los permisos mínimos necesarios.
    - Otorga solo los permisos específicos necesarios para cada operación
    - Revisa y audita regularmente el uso de permisos
    - Implementa acceso justo a tiempo para funciones administrativas

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.