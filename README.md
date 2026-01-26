# AR Mobile Experience

Experiência de Realidade Virtual desenvolvida em Unity, focada em dispositivos móveis, utilizando recursos de XR para criar uma experiência imersiva em ambiente 3D.

---

## 🎯 Objetivo

Este projeto tem como objetivo explorar conceitos de Realidade Aumentada em dispositivos móveis, incluindo:

- Experiência imersiva em AR
- Interação em ambientes 3D
- Pipeline de desenvolvimento e deploy para dispositivos móveis
- Boas práticas de versionamento com Git e Git LFS em projetos Unity

O projeto possui caráter educacional e experimental.

---

## 🕶️ Sobre a Experiência AR

- **Plataforma alvo:** Mobile
- **Dispositivos:** iOS
- **Tipo de AR:** Mobile AR (XR)
- **Execução:** Dispositivo físico (celular)

---

## 🛠️ Tecnologias Utilizadas

- **Unity** `2022.3.x LTS`
- **XR Plugin Management**
- **XR Interaction Toolkit**
- **C#**
- **Git**
- **Git LFS**

---

## 📋 Pré-requisitos

Antes de clonar e executar o projeto, certifique-se de ter os seguintes itens instalados:

### Geral
- [Unity Hub](https://unity.com/download)
- Unity Editor **2022.3.x LTS**
- Git
- Git LFS

Instalação do Git LFS:
```bash
git lfs install
```

### iOS
- macOS
- Xcode
- Conta Apple Developer
- iPhone compatível

## Como Rodar o Projeto Localmente

### Clonar o repositório
```bash
git clone https://github.com/joseph-cbp/ARcheology.git
cd ARcheology
```
### Abrir no Unity
1.	Abra o Unity Hub
2.	Clique em Open
3.	Selecione a pasta do projeto clonado
4.	Aguarde a importação dos assets

⏳ A primeira abertura pode levar alguns minutos, dependendo da máquina.

---

## Executando no Celular (AR)
1.	Conecte o iPhone
2.	No Unity:
    -	File > Build Settings
    -	Selecione iOS
	-	Clique em Build
3.	Abra o projeto gerado no Xcode
4.	Configure o Signing & Capabilities
5.	Execute no dispositivo físico

---

## Testes

- Testado em dispositivos físicos
- Recomenda-se sempre testar no celular, pois o Unity Editor não simula corretamente AR mobile
- Performance pode variar conforme o hardware do dispositivo

## Features
Além das features mostradas durante a Trilha Desenvolvimento para AR/VR fornecida pela Nexvisual, desenvolvi, experimentalmente algumas:
- Cilindro com movimentação: ao ser solto ele executa uma animação como se estivesse servindo algo.
- Modelos de Sushi: se tranformam ao toque.
- Elementos mudam de cor: ao serem colocados no Scanner, alguns elementos mudam de cor.
