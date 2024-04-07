import './App.css';
import { Helmet } from 'react-helmet-async';
import LayoutRenderer from './layout/LayoutRenderer';

function App() {
  return (
    <>
      <Helmet>
        <title>Hello World</title>
        <link rel="canonical" href="https://www.tacobell.com/" />
      </Helmet>
      <LayoutRenderer>
        <h1>Hello</h1>
      </LayoutRenderer>
    </>
  );

  // async function populateWeatherData() {
  //     const response = await fetch('weatherforecast');
  //     const data = await response.json();
  //     setForecasts(data);
  // }
}

export default App;
