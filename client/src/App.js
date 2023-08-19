import React, { useState } from 'react';
import NumbersApi from './api'; // Update the path to the api.js file
import './App.css';

const api = new NumbersApi();

function App() {
  const [numbers, setNumbers] = useState([0, 0, 0, 0, 0]);
  const [result, setResult] = useState(null);

  const handleInputChange = (index, value) => {
    const updatedNumbers = [...numbers];
    updatedNumbers[index] = parseInt(value);
    setNumbers(updatedNumbers);
  };

  const handleCalculate = async (endpoint) => {
    try {
      const result = await api.sendRequest(endpoint, numbers);
      setResult(result);
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="App">
      {/* number input areas */}
      {numbers.map((number, index) => (
        <input
          key={index}
          type="number"
          // placeholder={`Enter number ${index + 1}`}
          value={number}
          onChange={(e) => handleInputChange(index, e.target.value)}
        />
      ))}

      {/* Buttons for requests */}
      <div>
        <button onClick={() => handleCalculate(api.endpoints.add)}>Add Numbers</button>
        <button onClick={() => handleCalculate(api.endpoints.average)}>Average Numbers</button>
        <button onClick={() => handleCalculate(api.endpoints.lowest)}>Find Lowest</button>
        <button onClick={() => handleCalculate(api.endpoints.highest)}>Find Highest</button>
        <button onClick={() => handleCalculate(api.endpoints.difference)}>Find Range Difference</button>
      </div>
      {/* Display result */}
      <br></br>
      {result === null
      ?
        <div>
          <p>Input numbers and choose an option</p>
        </div>
      :
      <div>
        <p>{result}</p>
      </div>
      }
    </div>
  );
}

export default App;