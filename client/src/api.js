import axios from 'axios';

class NumbersApi {
  constructor() {
    this.apiUrl = 'http://localhost:5264/numbers';
    this.endpoints = {
      add: `${this.apiUrl}/add`,
      average: `${this.apiUrl}/average`,
      lowest: `${this.apiUrl}/lowest`,
      highest: `${this.apiUrl}/highest`,
      difference: `${this.apiUrl}/difference`,
    };
  }

  async sendRequest(endpoint, numbers) {
    try {
      const response = await axios.post(endpoint, numbers, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      console.log(response.data)
      return response.data;
    } catch (error) {
      console.error('Error:', error);
      throw error; // Re-throw the error to handle it where it's used
    }
  }
}

export default NumbersApi;