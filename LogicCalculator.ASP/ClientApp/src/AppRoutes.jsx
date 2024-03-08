import { Home } from './pages/Home';
import { AboutPage } from './pages/AboutPage';

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/about',
    element: <AboutPage />,
  },
];

export default AppRoutes;
