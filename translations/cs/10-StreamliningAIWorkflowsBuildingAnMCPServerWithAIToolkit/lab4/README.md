<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:56:14+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "cs"
}
-->
# 🐙 Module 4: Práctico Desarrollo MCP - Servidor Personalizado de Clonación GitHub

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ Inicio Rápido:** ¡Construye un servidor MCP listo para producción que automatiza la clonación de repositorios GitHub y la integración con VS Code en solo 30 minutos!

## 🎯 Objetivos de Aprendizaje

Al finalizar este laboratorio, podrás:

- ✅ Crear un servidor MCP personalizado para flujos de trabajo de desarrollo reales  
- ✅ Implementar la funcionalidad de clonación de repositorios GitHub vía MCP  
- ✅ Integrar servidores MCP personalizados con VS Code y Agent Builder  
- ✅ Usar GitHub Copilot Agent Mode con herramientas MCP personalizadas  
- ✅ Probar y desplegar servidores MCP personalizados en entornos productivos  

## 📋 Requisitos Previos

- Haber completado los laboratorios 1-3 (fundamentos y desarrollo avanzado de MCP)  
- Suscripción a GitHub Copilot ([registro gratuito disponible](https://github.com/github-copilot/signup))  
- VS Code con las extensiones AI Toolkit y GitHub Copilot instaladas  
- CLI de Git instalado y configurado  

## 🏗️ Resumen del Proyecto

### **Desafío Real de Desarrollo**  
Como desarrolladores, frecuentemente usamos GitHub para clonar repositorios y abrirlos en VS Code o VS Code Insiders. Este proceso manual implica:  
1. Abrir terminal o consola  
2. Navegar al directorio deseado  
3. Ejecutar el comando `git clone`  
4. Abrir VS Code en el directorio clonado  

**¡Nuestra solución MCP simplifica todo esto en un solo comando inteligente!**

### **Qué Construirás**  
Un **Servidor MCP de Clonación GitHub** (`git_mcp_server`) que ofrece:

| Característica | Descripción | Beneficio |
|----------------|-------------|-----------|
| 🔄 **Clonación Inteligente de Repositorios** | Clona repositorios GitHub con validación | Verificación automática de errores |
| 📁 **Gestión Inteligente de Directorios** | Verifica y crea directorios de forma segura | Evita sobrescritura accidental |
| 🚀 **Integración Multiplataforma con VS Code** | Abre proyectos en VS Code/Insiders | Transición fluida en el flujo de trabajo |
| 🛡️ **Manejo Robusto de Errores** | Gestiona problemas de red, permisos y rutas | Fiabilidad lista para producción |

---

## 📖 Implementación Paso a Paso

### Paso 1: Crear Agente GitHub en Agent Builder

1. **Abre Agent Builder** desde la extensión AI Toolkit  
2. **Crea un nuevo agente** con la siguiente configuración:  
   ```
   Agent Name: GitHubAgent
   ```

3. **Inicializa el servidor MCP personalizado:**  
   - Ve a **Tools** → **Add Tool** → **MCP Server**  
   - Selecciona **"Create A new MCP Server"**  
   - Escoge la **plantilla Python** para máxima flexibilidad  
   - **Nombre del servidor:** `git_mcp_server`  

### Paso 2: Configurar GitHub Copilot Agent Mode

1. **Abre GitHub Copilot** en VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")  
2. **Selecciona el modelo Agent** en la interfaz de Copilot  
3. **Elige el modelo Claude 3.7** para capacidades avanzadas de razonamiento  
4. **Activa la integración MCP** para acceso a herramientas  

> **💡 Consejo Profesional:** Claude 3.7 ofrece una comprensión superior de flujos de trabajo de desarrollo y patrones de manejo de errores.

### Paso 3: Implementar Funcionalidad Principal del Servidor MCP

**Usa el siguiente prompt detallado con GitHub Copilot Agent Mode:**  

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```

### Paso 4: Probar tu Servidor MCP

#### 4a. Prueba en Agent Builder

1. **Inicia la configuración de depuración** en Agent Builder  
2. **Configura tu agente con este prompt del sistema:**  

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **Prueba con escenarios realistas de usuario:**  

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.cs.png)

**Resultados Esperados:**  
- ✅ Clonación exitosa con confirmación de ruta  
- ✅ Lanzamiento automático de VS Code  
- ✅ Mensajes claros de error en escenarios inválidos  
- ✅ Manejo adecuado de casos límite  

#### 4b. Prueba en MCP Inspector

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.cs.png)

---

**🎉 ¡Felicidades!** Has creado exitosamente un servidor MCP práctico y listo para producción que resuelve desafíos reales en flujos de trabajo de desarrollo. Tu servidor personalizado de clonación GitHub demuestra el poder de MCP para automatizar y mejorar la productividad de desarrolladores.

### 🏆 Logros Desbloqueados:  
- ✅ **Desarrollador MCP** - Creaste un servidor MCP personalizado  
- ✅ **Automatizador de Flujos** - Simplificaste procesos de desarrollo  
- ✅ **Experto en Integración** - Conectaste múltiples herramientas de desarrollo  
- ✅ **Listo para Producción** - Construiste soluciones desplegables  

---

## 🎓 Finalización del Taller: Tu Trayectoria con Model Context Protocol

**Estimado Participante del Taller,**

¡Felicitaciones por completar los cuatro módulos del taller Model Context Protocol! Has avanzado desde comprender conceptos básicos del AI Toolkit hasta construir servidores MCP listos para producción que solucionan desafíos reales de desarrollo.

### 🚀 Recapitulación de tu Camino de Aprendizaje:

**[Módulo 1](../lab1/README.md)**: Comenzaste explorando fundamentos del AI Toolkit, pruebas de modelos y creación de tu primer agente AI.

**[Módulo 2](../lab2/README.md)**: Aprendiste la arquitectura MCP, integraste Playwright MCP y creaste tu primer agente de automatización de navegador.

**[Módulo 3](../lab3/README.md)**: Avanzaste en desarrollo de servidores MCP personalizados con el servidor Weather MCP y dominaste herramientas de depuración.

**[Módulo 4](../lab4/README.md)**: Ahora aplicaste todo para crear una herramienta práctica de automatización de flujo de trabajo de repositorios GitHub.

### 🌟 Lo que Dominas:

- ✅ **Ecosistema AI Toolkit**: Modelos, agentes y patrones de integración  
- ✅ **Arquitectura MCP**: Diseño cliente-servidor, protocolos de transporte y seguridad  
- ✅ **Herramientas para Desarrolladores**: Desde Playground hasta Inspector y despliegue en producción  
- ✅ **Desarrollo Personalizado**: Construcción, prueba y despliegue de servidores MCP propios  
- ✅ **Aplicaciones Prácticas**: Resolución de desafíos reales con IA  

### 🔮 Tus Próximos Pasos:

1. **Construye tu propio servidor MCP**: Aplica estas habilidades para automatizar tus flujos de trabajo únicos  
2. **Únete a la comunidad MCP**: Comparte tus creaciones y aprende de otros  
3. **Explora integraciones avanzadas**: Conecta servidores MCP con sistemas empresariales  
4. **Contribuye a código abierto**: Ayuda a mejorar las herramientas y documentación MCP  

Recuerda, este taller es solo el comienzo. El ecosistema Model Context Protocol está evolucionando rápidamente, y ahora estás preparado para estar a la vanguardia en herramientas de desarrollo impulsadas por IA.

**Gracias por tu participación y dedicación al aprendizaje!**

Esperamos que este taller haya inspirado ideas que transformarán cómo construyes e interactúas con herramientas AI en tu camino de desarrollo.

**¡Feliz codificación!**

---

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.