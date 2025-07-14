<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T02:02:03+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "br"
}
-->
## Exemplo: Implementação de Root Context para análise financeira

Neste exemplo, criaremos um root context para uma sessão de análise financeira, demonstrando como manter o estado ao longo de múltiplas interações.

## Exemplo: Gerenciamento de Root Context

Gerenciar root contexts de forma eficaz é fundamental para manter o histórico da conversa e o estado. Abaixo está um exemplo de como implementar o gerenciamento de root context.

## Root Context para Assistência Multi-Turnos

Neste exemplo, criaremos um root context para uma sessão de assistência multi-turnos, demonstrando como manter o estado ao longo de múltiplas interações.

## Melhores Práticas para Root Context

Aqui estão algumas melhores práticas para gerenciar root contexts de forma eficaz:

- **Crie Contextos Focados**: Crie root contexts separados para diferentes propósitos ou domínios da conversa para manter a clareza.

- **Defina Políticas de Expiração**: Implemente políticas para arquivar ou excluir contextos antigos para gerenciar o armazenamento e cumprir com políticas de retenção de dados.

- **Armazene Metadados Relevantes**: Use metadados do contexto para guardar informações importantes sobre a conversa que possam ser úteis posteriormente.

- **Use IDs de Contexto Consistentemente**: Uma vez criado um contexto, use seu ID de forma consistente para todas as requisições relacionadas para manter a continuidade.

- **Gere Resumos**: Quando um contexto crescer muito, considere gerar resumos para capturar as informações essenciais enquanto gerencia o tamanho do contexto.

- **Implemente Controle de Acesso**: Para sistemas multiusuário, implemente controles de acesso adequados para garantir a privacidade e segurança dos contextos de conversa.

- **Gerencie Limitações de Contexto**: Esteja ciente das limitações de tamanho do contexto e implemente estratégias para lidar com conversas muito longas.

- **Arquive Quando Concluído**: Arquive os contextos quando as conversas estiverem completas para liberar recursos, preservando o histórico da conversa.

## Próximos passos

- [5.5 Routing](../mcp-routing/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.