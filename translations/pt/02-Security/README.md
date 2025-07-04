<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T16:58:35+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações impulsionadas por IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Para além de preocupações já estabelecidas como codificação segura, princípio do menor privilégio e segurança da cadeia de fornecimento, o MCP e as cargas de trabalho de IA enfrentam novas ameaças como injeção de prompts, envenenamento de ferramentas e modificação dinâmica de ferramentas. Estes riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem geridos adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompts e vulnerabilidades na cadeia de fornecimento — e fornece controlos práticos e melhores práticas para os mitigar. Também aprenderá a tirar partido das soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para reforçar a sua implementação MCP. Ao compreender e aplicar estes controlos, pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que os seus sistemas de IA permanecem robustos e confiáveis.

# Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompts, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de fornecimento.
- Descrever e aplicar controlos eficazes para mitigar os riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gestão segura de tokens e verificação da cadeia de fornecimento.
- Compreender e utilizar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados das ferramentas, monitorizar alterações dinâmicas e defender-se contra ataques de injeção indireta de prompts.
- Integrar melhores práticas de segurança estabelecidas — como codificação segura, endurecimento de servidores e arquitetura de zero trust — na sua implementação MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controlos de segurança MCP

Qualquer sistema que tenha acesso a recursos importantes enfrenta desafios implícitos de segurança. Estes desafios podem, geralmente, ser abordados através da aplicação correta de controlos e conceitos fundamentais de segurança. Como o MCP é uma especificação recentemente definida, está a evoluir rapidamente. À medida que o protocolo evolui, os controlos de segurança nele incorporados irão amadurecer, permitindo uma melhor integração com arquiteturas empresariais e melhores práticas de segurança já estabelecidas.

Investigação publicada no [Microsoft Digital Defense Report](https://aka.ms/mddr) indica que 98% das violações reportadas poderiam ser evitadas com uma higiene de segurança robusta. A melhor proteção contra qualquer tipo de violação é garantir uma base sólida de higiene de segurança, melhores práticas de codificação segura e segurança da cadeia de fornecimento — essas práticas testadas e comprovadas continuam a ter o maior impacto na redução do risco de segurança.

Vamos analisar algumas formas de começar a abordar os riscos de segurança ao adotar o MCP.

> **Note:** A informação seguinte está correta até **29 de maio de 2025**. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controlos de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub](https://github.com/modelcontextprotocol) e a [página de melhores práticas de segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores iriam criar o seu próprio servidor de autenticação. Isto exigia conhecimento de OAuth e das restrições de segurança associadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerindo diretamente a autenticação do utilizador em vez de a delegar para um serviço externo como o Microsoft Entra ID. A partir de **26 de abril de 2025**, uma atualização da especificação MCP permite que os servidores MCP deleguem a autenticação do utilizador a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e à aplicação incorreta de controlos de acesso.
- Roubo de tokens OAuth no servidor MCP local. Se roubado, o token pode ser usado para se fazer passar pelo servidor MCP e aceder a recursos e dados do serviço para o qual o token OAuth foi emitido.

#### Passagem de Token
A passagem de token é explicitamente proibida na especificação de autorização, pois introduz vários riscos de segurança, incluindo:

#### Contorno de Controlos de Segurança
O servidor MCP ou APIs a jusante podem implementar controlos importantes de segurança como limitação de taxa, validação de pedidos ou monitorização de tráfego, que dependem do público-alvo do token ou outras restrições de credenciais. Se os clientes conseguirem obter e usar tokens diretamente com as APIs a jusante sem que o servidor MCP os valide corretamente ou assegure que os tokens foram emitidos para o serviço correto, estes controlos são contornados.

#### Problemas de Responsabilização e Auditoria
O servidor MCP não conseguirá identificar ou distinguir entre clientes MCP quando estes chamam com um token de acesso emitido a montante, que pode ser opaco para o servidor MCP.  
Os registos do servidor de recursos a jusante podem mostrar pedidos que parecem vir de uma fonte diferente com uma identidade diferente, em vez do servidor MCP que está a encaminhar os tokens.  
Ambos os fatores dificultam a investigação de incidentes, controlos e auditorias.  
Se o servidor MCP passar tokens sem validar as suas claims (por exemplo, funções, privilégios ou público-alvo) ou outros metadados, um ator malicioso na posse de um token roubado pode usar o servidor como proxy para exfiltração de dados.

#### Problemas de Limite de Confiança
O servidor de recursos a jusante concede confiança a entidades específicas. Esta confiança pode incluir pressupostos sobre a origem ou padrões de comportamento do cliente. Quebrar este limite de confiança pode levar a problemas inesperados.  
Se o token for aceite por múltiplos serviços sem validação adequada, um atacante que comprometa um serviço pode usar o token para aceder a outros serviços ligados.

#### Risco de Compatibilidade Futura
Mesmo que um servidor MCP comece hoje como um “proxy puro”, poderá precisar de adicionar controlos de segurança mais tarde. Começar com uma separação adequada do público-alvo do token facilita a evolução do modelo de segurança.

### Controlos de mitigação

**Os servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP**

- **Rever e Endurecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas os utilizadores e clientes pretendidos podem aceder a recursos sensíveis. Para orientação prática, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar Práticas Seguras de Token:** Siga as [melhores práticas da Microsoft para validação e duração de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Armazene sempre os tokens de forma segura e utilize encriptação para os proteger em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema  
Os servidores MCP podem ter sido concedidas permissões excessivas para o serviço/recurso a que acedem. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA que se conecta a um repositório de dados empresarial deve ter acesso limitado aos dados de vendas e não deve poder aceder a todos os ficheiros do repositório. Relembrando o princípio do menor privilégio (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões superiores às necessárias para executar as tarefas para as quais foi destinado. A IA apresenta um desafio acrescido neste domínio porque, para ser flexível, pode ser difícil definir exatamente as permissões necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não deveria poder aceder. Isto pode também constituir um problema de privacidade se os dados forem informações pessoalmente identificáveis (PII).

### Controlos de mitigação  
- **Aplicar o Princípio do Menor Privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar as suas tarefas. Reveja e atualize regularmente estas permissões para garantir que não excedem o necessário. Para orientação detalhada, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controlo de Acesso Baseado em Funções (RBAC):** Atribua ao servidor MCP funções que sejam estritamente limitadas a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorizar e Auditar Permissões:** Monitorize continuamente o uso das permissões e audite os registos de acesso para detetar e corrigir privilégios excessivos ou não utilizados de forma rápida.

# Ataques de injeção indireta de prompts

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Estes riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA execute ações não intencionais ou divulgue dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controlos de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt Cross-Domain:** Instruções maliciosas são inseridas em documentos, páginas web ou emails, que são depois processados pela IA, levando a fugas ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** As definições das ferramentas podem ser alteradas após aprovação do utilizador, introduzindo novos comportamentos maliciosos sem o conhecimento do utilizador.

Estas vulnerabilidades destacam a necessidade de validação robusta, monitorização e controlos de segurança ao integrar servidores MCP e ferramentas no seu ambiente. Para uma análise mais aprofundada, consulte as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pt.png)

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Neste ataque, instruções maliciosas são ocultadas em conteúdos externos — como documentos, páginas web ou emails. Quando o sistema de IA processa este conteúdo, pode interpretar as instruções embutidas como comandos legítimos do utilizador, resultando em ações não intencionais como fuga de dados, geração de conteúdo prejudicial ou manipulação das interações do utilizador. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa deste ataque é o **Envenenamento de Ferramentas**. Aqui, os atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem destes metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas de ferramentas não autorizadas ou contornar controlos de segurança. Estas manipulações são frequentemente invisíveis para os utilizadores finais, mas podem ser interpretadas e executadas pelo sistema de IA. Este risco é agravado em ambientes de servidores MCP alojados, onde as definições das ferramentas podem ser atualizadas após aprovação do utilizador — um cenário por vezes referido como "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nestes casos, uma ferramenta que antes era segura pode ser modificada posteriormente para realizar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do utilizador. Para mais informações sobre este vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pt.png)

## Riscos  
Ações não intencionais da IA apresentam vários riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controlos de mitigação  
### Uso de prompt shields para proteger contra ataques de Injeção Indireta de Prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt diretos e indiretos. Ajudam através de:

1.  **Deteção e Filtragem:** Os Prompt Shields utilizam algoritmos avançados de machine learning e processamento de linguagem natural para detetar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou emails.
    
2.  **Spotlighting:** Esta técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma a torná-lo mais relevante para o modelo, o Spotlighting garante que a IA consegue identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e Datamarking:** Incluir delimitadores na mensagem do sistema define explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar as entradas do utilizador de conteúdos externos potencialmente prejudiciais. O Datamarking estende este conceito usando marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitorização Contínua e Atualizações:** A Microsoft monitoriza e atualiza continuamente os Prompt Shields para responder a ameaças novas e em evolução. Esta abordagem proativa garante que as defesas permanecem eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Os Prompt Shields fazem parte da suíte mais ampla Azure AI Content Safety, que fornece ferramentas adicionais para detetar tentativas de jailbreak, conteúdos prejudiciais e outros riscos de segurança em aplicações de IA.

Pode ler mais sobre os AI prompt shields na [documentação Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pt.png)

### Segurança da cadeia de fornecimento
A segurança da cadeia de fornecimento continua a ser fundamental na era da IA, mas o âmbito do que constitui a sua cadeia de fornecimento expandiu-se. Para além dos pacotes de código tradicionais, deve agora verificar e monitorizar rigorosamente todos os componentes relacionados com IA, incluindo modelos base, serviços de embeddings, fornecedores de contexto e APIs de terceiros. Cada um destes pode introduzir vulnerabilidades ou riscos se não forem geridos adequadamente.

**Práticas-chave de segurança da cadeia de fornecimento para IA e MCP:**
- **Verifique todos os componentes antes da integração:** Isto inclui não só bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Verifique sempre a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Mantenha pipelines de deployment seguros:** Utilize pipelines CI/CD automatizados com análise de segurança integrada para detetar problemas precocemente. Garanta que apenas artefactos confiáveis são implementados em produção.
- **Monitorize e audite continuamente:** Implemente monitorização contínua para todas as dependências, incluindo modelos e serviços de dados, para detetar novas vulnerabilidades ou ataques à cadeia de fornecimento.
- **Aplique o princípio do menor privilégio e controlos de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.
- **Responda rapidamente a ameaças:** Tenha um processo para corrigir ou substituir componentes comprometidos e para rotacionar segredos ou credenciais caso seja detetada uma violação.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece funcionalidades como scanning de segredos, scanning de dependências e análise CodeQL. Estas ferramentas integram-se com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar as equipas a identificar e mitigar vulnerabilidades tanto no código como nos componentes da cadeia de fornecimento de IA.

A Microsoft também implementa práticas extensivas de segurança da cadeia de fornecimento internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Práticas de segurança estabelecidas que irão reforçar a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da sua organização onde está construída, por isso, ao considerar a segurança do MCP como um componente dos seus sistemas globais de IA, recomenda-se que melhore a sua postura de segurança geral já existente. Os seguintes controlos de segurança estabelecidos são especialmente relevantes:

-   Melhores práticas de codificação segura na sua aplicação de IA – proteja-se contra [o OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes da aplicação, etc.
-   Endurecimento do servidor – utilize MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com um fornecedor de identidade externo para acesso, etc.
-   Mantenha dispositivos, infraestrutura e aplicações atualizados com patches
-   Monitorização de segurança – implemente registo e monitorização de uma aplicação de IA (incluindo o cliente/servidores MCP) e envie esses registos para um SIEM central para deteção de atividades anómalas
-   Arquitetura de zero trust – isole componentes através de controlos de rede e identidade de forma lógica para minimizar movimentos laterais caso uma aplicação de IA seja comprometida.

# Principais conclusões

- Os fundamentos de segurança continuam críticos: codificação segura, princípio do menor privilégio, verificação da cadeia de fornecimento e monitorização contínua são essenciais para cargas de trabalho MCP e IA.
- O MCP introduz novos riscos — como injeção de prompts, envenenamento de ferramentas e permissões excessivas — que requerem controlos tradicionais e específicos para IA.
- Utilize práticas robustas de autenticação, autorização e gestão de tokens, aproveitando fornecedores de identidade externos como o Microsoft Entra ID sempre que possível.
- Proteja-se contra injeção indireta de prompts e envenenamento de ferramentas validando metadados das ferramentas, monitorizando alterações dinâmicas e utilizando soluções como o Microsoft Prompt Shields.
- Trate todos os componentes da sua cadeia de fornecimento de IA — incluindo modelos, embeddings e fornecedores de contexto — com o mesmo rigor que as dependências de código.
- Mantenha-se atualizado com as especificações MCP em evolução e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos adicionais

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Seguinte

Seguinte: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.