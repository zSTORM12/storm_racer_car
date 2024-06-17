
# STORM RACER

**Descrição do Jogo:**

STORM RACER é um emocionante jogo de corrida onde os jogadores podem competir em pistas desafiadoras, enfrentar rampas e obstáculos, e explorar a física realista de quedas. Com gráficos vibrantes e uma jogabilidade envolvente, STorm RACER oferece uma experiência de corrida única e divertida.

**Instruções para Jogabilidade:**

- **Movimentação:** Use as teclas W, A, S, D para controlar o veículo.
- **Pular:** Pressione a tecla Espaço para pular (se aplicável).
- **Controle da Câmera:** Use o mouse para ajustar a câmera.
- **Interação com Objetos:** Aproximar-se de rampas e lombadas para interagir.

---

**Gameplay:**

Confira um vídeo de gameplay do nosso jogo:

[![Gameplay Video](link_do_print_da_capa_do_video)](https://www.youtube.com/watch?v=link_do_video)

---

**Prints de Tela:**

**Menu Principal:**

![Menu Principal](/prints/menu.png)

**Interação com Objetos (Rampa):**

![Interação com Objetos (Rampa)](/prints/interacao_objetos(rampa).png)

**Interação com Lombada:**

![Interação com Lombada](/prints/interacao_lombada.png)

**Fisica de Cair:**

![Fisica de Cair](/prints/fisica_cair.png)

---

**Funcionalidades Desenvolvidas:**

1. **Interação com Objetos (Rampa):**
   Foi desenvolvido um sistema de interação com rampas que permite ao jogador realizar saltos e manobras durante a corrida, aumentando a emoção e a imprevisibilidade da gameplay.

   **Código da Interação com Rampas:**
   ```csharp
   private void BoostTorque()
   {
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
           frontLeftWheelCollider.motorTorque = motorForce * 50;
           frontRightWheelCollider.motorTorque = motorForce * 50;
           backLeftWheelCollider.motorTorque = motorForce * 50;
           backRightWheelCollider.motorTorque = motorForce * 50;
       }
   }
   ```

   **Print da Interação com Rampas:**

   ![Interação com Objetos (Rampa)](/prints/interacao_objetos(rampa).png)

2. **Interação com Lombada:**
   Implementamos uma funcionalidade de interação com lombadas, que cria uma dinâmica realista de desaceleração e aumento de dificuldade, proporcionando uma experiência de corrida mais desafiadora.

   **Código da Interação com Lombadas:**
   ```csharp
   private void ApplyBreaking()
   {
       //frontLeftWheelCollider.brakeTorque = currentbreakForce;
       //frontRightWheelCollider.brakeTorque = currentbreakForce;
       backLeftWheelCollider.brakeTorque = currentbreakForce;
       backRightWheelCollider.brakeTorque = currentbreakForce;
   }
   ```

   **Print da Interação com Lombadas:**

   ![Interação com Lombada](/prints/interacao_lombada.png)

3. **Fisica de Cair:**
   A física de cair foi implementada para simular quedas realistas quando o veículo sai da pista ou salta de uma rampa, adicionando um elemento de risco e estratégia à corrida.

   **Código da Física de Cair:**
   ```csharp
   private void HandleMotor()
   {
       frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
       frontRightWheelCollider.motorTorque = verticalInput * motorForce;
       backLeftWheelCollider.motorTorque = verticalInput * motorForce;
       backRightWheelCollider.motorTorque = verticalInput * motorForce;

       currentbreakForce = isBreaking ? breakForce : 0f;
       ApplyBreaking();  
   }
   ```

   **Print da Física de Cair:**

   ![Fisica de Cair](/prints/fisica_cair.png)
