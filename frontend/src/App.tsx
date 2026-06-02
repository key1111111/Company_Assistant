import { useState } from "react";
import axios from "axios";

function App() {
  const [question, setQuestion] = useState("");
  const [answer, setAnswer] = useState("");
  const [source, setSource] = useState("");

  const ask = async () => {
    const response = await axios.post(
      "http://localhost:5207/api/ask",
      {
        question
      });

    setAnswer(response.data.answer);
    setSource(response.data.source);
  };

  return (
    <div style={{
      maxWidth: 900,
      margin: "40px auto"
    }}>
      <h1>Company Assistant</h1>

      <input
        value={question}
        onChange={e =>
          setQuestion(e.target.value)}
        placeholder="Ask a question..."
        style={{
          width: "100%",
          padding: "12px"
        }}
      />

      <button
        onClick={ask}
        style={{
          marginTop: "10px"
        }}>
        Search
      </button>

      <hr />

      <h3>Answer</h3>

      <pre>{answer}</pre>

      <p>
        Source: {source}
      </p>
    </div>
  );
}

export default App;