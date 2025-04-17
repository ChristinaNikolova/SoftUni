<script>
export default {
  data() {
    return {
      isThinking: false,
      isAnswer: false,
      answer: "",
      answers: ["yes", "no", "maybe", "ask me again", "i don't know"],
    };
  },

  methods: {
    thinking() {
      this.isThinking = true;
      this.isAnswer = false;
      this.answer = "";
      setTimeout(() => {
        this.isThinking = false;
        this.isAnswer = true;
        this.answer =
          this.answers[Math.floor(Math.random() * this.answers.length)];
      }, 3000);
    },
  },
};
</script>

<template>
  <div class="app-wrapper">
    <div class="image-wrapper">
      <img
        src="https://magic-8ball.com/wp-content/uploads/ball.png"
        alt="8-ball"
      />
    </div>
    <p v-if="isAnswer" class="answer">{{ answer }}</p>
    <div v-if="isThinking" class="thinking-wrapper">
      <p class="thinking-text">Thinking</p>
      <div class="snippet" data-title="dot-pulse">
        <div class="stage">
          <div class="dot-pulse"></div>
        </div>
      </div>
    </div>
    <button @click="thinking" class="button">Ask me a question</button>
  </div>
</template>

<style scoped>
.app-wrapper {
  height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 30px;
  font-family: Arial, Helvetica, sans-serif;
  text-transform: uppercase;
}

.thinking-wrapper {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 10px;
  margin-bottom: 20px;
}

.answer {
  color: gray;
  font-size: 26px;
  font-weight: 600;
  margin: 40px;
}

.thinking-text {
  font-size: 40px;
  font-weight: 600;
  color: #9880ff;
  letter-spacing: 1.2px;
  line-height: 1.5;
}

.button {
  border-radius: 8px;
  background-color: #9880ff;
  color: white;
  border: none;
  outline: none;
  text-transform: uppercase;
  padding: 20px 35px;
  font-size: 18px;
}

.button:hover {
  cursor: pointer;
  font-weight: 600;
}
.dot-pulse {
  position: relative;
  left: -9999px;
  width: 10px;
  height: 10px;
  border-radius: 5px;
  background-color: #9880ff;
  color: #9880ff;
  box-shadow: 9999px 0 0 -5px;
  animation: dot-pulse 1.5s infinite linear;
  animation-delay: 0.25s;
}
.dot-pulse::before,
.dot-pulse::after {
  content: "";
  display: inline-block;
  position: absolute;
  top: 0;
  width: 10px;
  height: 10px;
  border-radius: 5px;
  background-color: #9880ff;
  color: #9880ff;
}
.dot-pulse::before {
  box-shadow: 9984px 0 0 -5px;
  animation: dot-pulse-before 1.5s infinite linear;
  animation-delay: 0s;
}
.dot-pulse::after {
  box-shadow: 10014px 0 0 -5px;
  animation: dot-pulse-after 1.5s infinite linear;
  animation-delay: 0.5s;
}

@keyframes dot-pulse-before {
  0% {
    box-shadow: 9975px 0 0 -5px;
  }
  30% {
    box-shadow: 9975px 0 0 2px;
  }
  60%,
  100% {
    box-shadow: 9975px 0 0 -5px;
  }
}
@keyframes dot-pulse {
  0% {
    box-shadow: 9999px 0 0 -5px;
  }
  30% {
    box-shadow: 9999px 0 0 2px;
  }
  60%,
  100% {
    box-shadow: 9999px 0 0 -5px;
  }
}
@keyframes dot-pulse-after {
  0% {
    box-shadow: 10014px 0 0 -5px;
  }
  30% {
    box-shadow: 10014px 0 0 2px;
  }
  60%,
  100% {
    box-shadow: 10014px 0 0 -5px;
  }
}
</style>
