<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:02:50+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "ko"
}
-->
# AI 워크플로우 간소화: AI Toolkit으로 MCP 서버 구축하기

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.ko.png)

## 🎯 개요

**Model Context Protocol (MCP) 워크숍**에 오신 것을 환영합니다! 이 실습 워크숍은 두 가지 최첨단 기술을 결합하여 AI 애플리케이션 개발에 혁신을 가져옵니다:

- **🔗 Model Context Protocol (MCP)**: AI 도구 통합을 위한 오픈 표준
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: 마이크로소프트의 강력한 AI 개발 확장 도구

### 🎓 배울 내용

워크숍이 끝나면 AI 모델과 실제 도구 및 서비스를 연결하는 지능형 애플리케이션 구축 기술을 익히게 됩니다. 자동화된 테스트부터 맞춤형 API 통합까지, 복잡한 비즈니스 문제를 해결할 실무 능력을 갖추게 됩니다.

## 🏗️ 기술 스택

### 🔌 Model Context Protocol (MCP)

MCP는 AI를 위한 **"USB-C"**와 같은 보편적인 표준으로, AI 모델을 외부 도구와 데이터 소스에 연결합니다.

**✨ 주요 특징:**
- 🔄 **표준화된 통합**: AI 도구 연결을 위한 범용 인터페이스
- 🏛️ **유연한 아키텍처**: stdio/SSE 전송을 통한 로컬 및 원격 서버 지원
- 🧰 **풍부한 생태계**: 도구, 프롬프트, 리소스를 하나의 프로토콜로 통합
- 🔒 **기업용 준비**: 내장된 보안성과 신뢰성

**🎯 MCP가 중요한 이유:**
USB-C가 케이블 혼란을 없앴듯, MCP는 AI 통합의 복잡함을 해소합니다. 하나의 프로토콜로 무한한 가능성을 열어줍니다.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

마이크로소프트의 대표 AI 개발 확장으로, VS Code를 AI 개발의 강력한 플랫폼으로 변모시킵니다.

**🚀 핵심 기능:**
- 📦 **모델 카탈로그**: Azure AI, GitHub, Hugging Face, Ollama의 모델 접근
- ⚡ **로컬 추론**: ONNX 최적화 CPU/GPU/NPU 실행 지원
- 🏗️ **에이전트 빌더**: MCP 통합을 통한 시각적 AI 에이전트 개발
- 🎭 **멀티모달 지원**: 텍스트, 비전, 구조화된 출력 지원

**💡 개발 혜택:**
- 설정 없이 바로 모델 배포 가능
- 시각적 프롬프트 엔지니어링
- 실시간 테스트 플레이그라운드
- 원활한 MCP 서버 통합

## 📚 학습 여정

### [🚀 모듈 1: AI Toolkit 기초](./lab1/README.md)
**소요 시간**: 15분
- 🛠️ VS Code용 AI Toolkit 설치 및 설정
- 🗂️ 모델 카탈로그 탐색 (GitHub, ONNX, OpenAI, Anthropic, Google의 100개 이상 모델)
- 🎮 실시간 모델 테스트를 위한 인터랙티브 플레이그라운드 마스터
- 🤖 Agent Builder로 첫 AI 에이전트 구축
- 📊 내장 지표(F1, 관련성, 유사성, 일관성)로 모델 성능 평가
- ⚡ 배치 처리 및 멀티모달 지원 기능 학습

**🎯 학습 목표**: AITK 기능을 완벽히 이해하고 실용적인 AI 에이전트 제작

### [🌐 모듈 2: MCP와 AI Toolkit 기초](./lab2/README.md)
**소요 시간**: 20분
- 🧠 Model Context Protocol (MCP) 아키텍처 및 개념 습득
- 🌐 마이크로소프트 MCP 서버 생태계 탐색
- 🤖 Playwright MCP 서버를 활용한 브라우저 자동화 에이전트 구축
- 🔧 MCP 서버와 AI Toolkit Agent Builder 통합
- 📊 에이전트 내 MCP 도구 구성 및 테스트
- 🚀 MCP 기반 에이전트 내보내기 및 프로덕션 배포

**🎯 학습 목표**: 외부 도구와 연동된 AI 에이전트 배포 능력 습득

### [🔧 모듈 3: AI Toolkit을 활용한 고급 MCP 개발](./lab3/README.md)
**소요 시간**: 20분
- 💻 AI Toolkit으로 맞춤형 MCP 서버 제작
- 🐍 최신 MCP Python SDK (v1.9.3) 설정 및 활용
- 🔍 MCP Inspector를 통한 디버깅 환경 구축 및 사용
- 🛠️ 전문 디버깅 워크플로우로 날씨 MCP 서버 개발
- 🧪 Agent Builder와 Inspector 환경에서 MCP 서버 디버깅

**🎯 학습 목표**: 최신 도구를 활용한 맞춤형 MCP 서버 개발 및 디버깅

### [🐙 모듈 4: 실전 MCP 개발 - 맞춤형 GitHub 클론 서버](./lab4/README.md)
**소요 시간**: 30분
- 🏗️ 실제 개발 워크플로우를 위한 GitHub Clone MCP 서버 구축
- 🔄 검증 및 오류 처리를 포함한 스마트 저장소 클론 구현
- 📁 지능형 디렉터리 관리 및 VS Code 통합
- 🤖 맞춤형 MCP 도구와 함께 GitHub Copilot Agent 모드 활용
- 🛡️ 프로덕션 수준의 신뢰성 및 크로스 플랫폼 호환성 적용

**🎯 학습 목표**: 실제 개발 환경에 최적화된 MCP 서버 배포

## 💡 실제 적용 사례 및 영향

### 🏢 기업 활용 사례

#### 🔄 DevOps 자동화
지능형 자동화로 개발 워크플로우 혁신:
- **스마트 저장소 관리**: AI 기반 코드 리뷰 및 병합 결정
- **지능형 CI/CD**: 코드 변경에 따른 자동 파이프라인 최적화
- **이슈 분류**: 버그 자동 분류 및 할당

#### 🧪 품질 보증 혁신
AI 기반 자동화로 테스트 수준 향상:
- **지능형 테스트 생성**: 자동으로 포괄적인 테스트 스위트 생성
- **시각적 회귀 테스트**: AI 기반 UI 변경 감지
- **성능 모니터링**: 사전 문제 탐지 및 해결

#### 📊 데이터 파이프라인 지능화
더 똑똑한 데이터 처리 워크플로우 구축:
- **적응형 ETL 프로세스**: 스스로 최적화되는 데이터 변환
- **이상 탐지**: 실시간 데이터 품질 모니터링
- **지능형 라우팅**: 스마트 데이터 흐름 관리

#### 🎧 고객 경험 향상
탁월한 고객 상호작용 창출:
- **컨텍스트 인지 지원**: 고객 이력에 접근 가능한 AI 에이전트
- **사전 대응 문제 해결**: 예측 기반 고객 서비스
- **멀티채널 통합**: 플랫폼 전반에 걸친 통합 AI 경험

## 🛠️ 사전 준비 및 설정

### 💻 시스템 요구사항

| 구성 요소 | 요구사항 | 비고 |
|-----------|----------|------|
| **운영체제** | Windows 10 이상, macOS 10.15 이상, Linux | 최신 OS 권장 |
| **Visual Studio Code** | 최신 안정 버전 | AITK 사용 필수 |
| **Node.js** | v18.0 이상 및 npm | MCP 서버 개발용 |
| **Python** | 3.10 이상 | Python MCP 서버 선택 사항 |
| **메모리** | 최소 8GB RAM | 로컬 모델 사용 시 16GB 권장 |

### 🔧 개발 환경

#### 권장 VS Code 확장
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - 선택 사항이지만 유용함

#### 선택 도구
- **uv**: 최신 Python 패키지 관리자
- **MCP Inspector**: MCP 서버 시각적 디버깅 도구
- **Playwright**: 웹 자동화 예제용

## 🎖️ 학습 성과 및 인증 경로

### 🏆 역량 마스터 체크리스트

워크숍 완료 시 다음 역량을 갖추게 됩니다:

#### 🎯 핵심 역량
- [ ] **MCP 프로토콜 숙련**: 아키텍처 및 구현 패턴 심층 이해
- [ ] **AITK 전문성**: AI Toolkit을 활용한 신속한 개발 능력
- [ ] **맞춤형 서버 개발**: 프로덕션용 MCP 서버 구축, 배포, 유지 관리
- [ ] **도구 통합 우수성**: AI와 기존 개발 워크플로우의 원활한 연결
- [ ] **문제 해결 적용**: 실제 비즈니스 문제에 학습 내용 적용

#### 🔧 기술 역량
- [ ] VS Code에서 AI Toolkit 설치 및 설정
- [ ] 맞춤형 MCP 서버 설계 및 구현
- [ ] GitHub 모델과 MCP 아키텍처 통합
- [ ] Playwright를 활용한 자동화 테스트 워크플로우 구축
- [ ] 프로덕션용 AI 에이전트 배포
- [ ] MCP 서버 성능 디버깅 및 최적화

#### 🚀 고급 역량
- [ ] 기업 규모 AI 통합 아키텍처 설계
- [ ] AI 애플리케이션 보안 모범 사례 구현
- [ ] 확장 가능한 MCP 서버 아키텍처 설계
- [ ] 특정 도메인 맞춤형 도구 체인 제작
- [ ] AI 네이티브 개발 멘토링

## 📖 추가 자료
- [MCP 사양](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub 저장소](https://github.com/microsoft/vscode-ai-toolkit)
- [샘플 MCP 서버 모음](https://github.com/modelcontextprotocol/servers)
- [모범 사례 가이드](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 AI 개발 워크플로우 혁신할 준비 되셨나요?**

MCP와 AI Toolkit으로 지능형 애플리케이션의 미래를 함께 만들어 갑시다!

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.