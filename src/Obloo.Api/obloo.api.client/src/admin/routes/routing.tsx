import { createBrowserRouter, RouteObject } from 'react-router-dom';
import App from '../App';
import EmployeeList from '../components/pages/employee/employee';
import EmployeeCreateAndUpdate from '../components/pages/employee/employeeCreateAndUpdate';

const routesConfig: RouteObject[] = [
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '',
        element: <EmployeeList />,
      },
      {
        path: '/create',
        element: <EmployeeCreateAndUpdate />,
      },
    ],
  },
];

const router = createBrowserRouter(routesConfig);

export default router;
