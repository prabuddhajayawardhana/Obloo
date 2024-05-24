import './App.css';
import { Helmet } from 'react-helmet-async';
import LayoutRenderer from './layout/LayoutRenderer';
import { Outlet } from 'react-router-dom';

function App() {
  return (
    <>
      <Helmet>
        <title>Hello World</title>
      </Helmet>
      <LayoutRenderer>
        <Outlet />
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
