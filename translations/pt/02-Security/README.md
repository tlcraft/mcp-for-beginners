<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:04:41+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pt"
}
-->
# Práticas recomendadas de segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações impulsionadas por IA, mas também introduz desafios únicos de segurança que vão além dos riscos tradicionais de software. Além das preocupações já conhecidas, como codificação segura, princípio do menor privilégio e segurança da cadeia de suprimentos, o MCP e as cargas de trabalho de IA enfrentam novas ameaças, como prompt injection, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos indesejados do sistema se não forem gerenciados adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, prompt injection indireto e vulnerabilidades na cadeia de suprimentos — e apresenta controles e práticas recomendadas para mitigá-los. Você também aprenderá como utilizar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para fortalecer sua implementação do MCP. Ao entender e aplicar esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo prompt injection, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Compreender e aproveitar soluções da Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e de IA.
- Reconhecer a importância de validar metadados de ferramentas, monitorar alterações dinâmicas e defender-se contra ataques de prompt injection indireto.
- Integrar práticas de segurança consolidadas — como codificação segura, fortalecimento de servidores e arquitetura zero trust — na sua implementação do MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança do MCP

Qualquer sistema que tenha acesso a recursos importantes apresenta desafios implícitos de segurança. Esses desafios podem, em geral, ser tratados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP foi definido recentemente, sua especificação está mudando rapidamente e evoluindo. Eventualmente, os controles de segurança nele incorporados amadurecerão, permitindo uma melhor integração com arquiteturas empresariais e práticas de segurança já estabelecidas.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) afirmam que 98% das violações relatadas poderiam ser evitadas com uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é garantir uma base sólida em higiene de segurança, melhores práticas de codificação segura e segurança da cadeia de suprimentos — essas práticas testadas e comprovadas ainda têm o maior impacto na redução do risco de segurança.

Vamos analisar algumas formas de começar a tratar os riscos de segurança ao adotar o MCP.

# Autenticação do servidor MCP (se sua implementação MCP for anterior a 26 de abril de 2025)

> **Note:** As informações a seguir estão corretas até 26 de abril de 2025. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controles de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub](https://github.com/modelcontextprotocol).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando a autenticação do usuário diretamente, em vez de delegá-la a um serviço externo, como o Microsoft Entra ID. A partir de 26 de abril de 2025, uma atualização na especificação MCP permite que os servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e aplicação incorreta de controles de acesso.
- Roubo de token OAuth no servidor MCP local. Se o token for roubado, ele pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

### Controles mitigadores
- **Revisar e fortalecer a lógica de autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados possam acessar recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar práticas seguras de token:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de token.
- **Proteger o armazenamento de tokens:** Sempre armazene tokens de forma segura e utilize criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema  
Servidores MCP podem ter recebido permissões excessivas para o serviço ou recurso ao qual acessam. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA conectada a um repositório de dados corporativo deve ter acesso restrito apenas aos dados de vendas, e não a todos os arquivos do repositório. Retomando o princípio do menor privilégio (um dos princípios mais antigos da segurança), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nessa área porque, para garantir flexibilidade, pode ser difícil definir exatamente as permissões necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode representar um problema de privacidade se os dados forem informações pessoais identificáveis (PII).

### Controles mitigadores
- **Aplicar o princípio do menor privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, consulte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar controle de acesso baseado em função (RBAC):** Atribua funções ao servidor MCP que sejam estritamente limitadas a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorar e auditar permissões:** Monitore continuamente o uso de permissões e audite os registros de acesso para detectar e corrigir privilégios excessivos ou não utilizados rapidamente.

# Ataques de prompt injection indireto

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem representar riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Prompt Injection Attacks:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA execute ações não desejadas ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Atacantes manipulam metadados de ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Instruções maliciosas são embutidas em documentos, páginas web ou e-mails, que são então processados pela IA, levando a vazamento ou manipulação de dados.
- **Dynamic Tool Modification (Rug Pulls):** Definições de ferramentas podem ser alteradas após aprovação do usuário, introduzindo comportamentos maliciosos sem o conhecimento dele.

Essas vulnerabilidades ressaltam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores MCP e ferramentas ao seu ambiente. Para uma análise mais profunda, consulte as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pt.png)

**Prompt Injection Indireto** (também conhecido como cross-domain prompt injection ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo os que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas ficam ocultas em conteúdos externos — como documentos, páginas web ou e-mails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções embutidas como comandos legítimos do usuário, resultando em ações não intencionais, como vazamento de dados, geração de conteúdo nocivo ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Tool Poisoning**. Nesse caso, os atacantes inserem instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas não autorizadas ou contornar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é maior em ambientes hospedados de servidores MCP, onde definições de ferramentas podem ser atualizadas após aprovação do usuário — um cenário às vezes chamado de "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que antes era segura pode ser modificada para executar ações maliciosas, como exfiltrar dados ou alterar o comportamento do sistema, sem o conhecimento do usuário. Para mais informações sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pt.png)

## Riscos  
Ações não intencionais da IA apresentam diversos riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controles mitigadores  
### Usando prompt shields para proteger contra ataques de Prompt Injection Indireto
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de prompt injection diretos e indiretos. Eles atuam por meio de:

1.  **Detecção e filtragem:** Prompt Shields utilizam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou e-mails.
    
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma que fique mais relevante para o modelo, o Spotlighting garante que a IA possa identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e datamarking:** Incluir delimitadores na mensagem do sistema define explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar as entradas do usuário de conteúdos externos potencialmente prejudiciais. O datamarking amplia esse conceito ao usar marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitoramento e atualizações contínuas:** A Microsoft monitora e atualiza continuamente os Prompt Shields para enfrentar ameaças novas e em evolução. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Os Prompt Shields fazem parte da suíte Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdos nocivos e outros riscos de segurança em aplicações de IA.

Você pode ler mais sobre AI prompt shields na [documentação do Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pt.png)

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora é preciso verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um desses pode introduzir vulnerabilidades ou riscos se não for gerenciado adequadamente.

**Práticas-chave de segurança da cadeia de suprimentos para IA e MCP:**
- **Verifique todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Sempre verifique a procedência, licenciamento e vulnerabilidades conhecidas.
- **Mantenha pipelines de implantação seguros:** Use pipelines automatizados de CI/CD com varredura de segurança integrada para identificar problemas precocemente. Garanta que apenas artefatos confiáveis sejam implantados em produção.
- **Monitore e audite continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques na cadeia de suprimentos.
- **Aplique princípio do menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do servidor MCP.
- **Responda rapidamente a ameaças:** Tenha um processo para corrigir ou substituir componentes comprometidos e para rotacionar segredos ou credenciais caso uma violação seja detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como varredura de segredos, análise de dependências e CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensivas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Práticas consolidadas de segurança que elevarão a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da sua organização onde está construída, então, ao considerar a segurança do MCP como parte dos seus sistemas de IA, recomenda-se elevar a postura de segurança geral já existente. Os seguintes controles de segurança consolidados são especialmente relevantes:

- Melhores práticas de codificação segura na sua aplicação de IA — proteja contra [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras ponta a ponta entre todos os componentes da aplicação, etc.
- Fortalecimento de servidores — use MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com um provedor de identidade terceirizado para acesso, etc.
- Mantenha dispositivos, infraestrutura e aplicações atualizados com patches.
- Monitoramento de segurança — implemente logging e monitoramento da aplicação de IA (incluindo clientes/servidores MCP) e envie esses logs para um SIEM central para detectar atividades anômalas.
- Arquitetura zero trust — isole componentes via controles de rede e identidade de forma lógica para minimizar movimentos laterais caso uma aplicação de IA seja comprometida.

# Principais conclusões

- Fundamentos de segurança continuam essenciais: codificação segura, princípio do menor privilégio, verificação da cadeia de suprimentos e monitoramento contínuo são indispensáveis para cargas de trabalho MCP e IA.
- O MCP introduz novos riscos — como prompt injection, envenenamento de ferramentas e permissões excessivas — que exigem controles tradicionais e específicos para IA.
- Utilize práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.
- Proteja-se contra prompt injection indireto e envenenamento de ferramentas validando metadados de ferramentas, monitorando alterações dinâmicas e usando soluções como Microsoft Prompt Shields.
- Trate todos os componentes da sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor que as dependências de código.
- Mantenha-se atualizado com as especificações em evolução do MCP e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos adicionais

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A Jornada para Garantir a Segurança da Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso Seguro com Privilégio Mínimo (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores Práticas para Validação e Tempo de Vida de Tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Armazenamento Seguro de Tokens e Encripte os Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como Gateway de Autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usando Microsoft Entra ID para Autenticar com Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo

Próximo: [Capítulo 3: Começando](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.