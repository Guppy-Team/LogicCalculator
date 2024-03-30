import React, { ReactElement } from 'react';

import { HomePage } from './pages/HomePage';
import { AboutPage } from './pages/AboutPage';

interface Route {
  index?: boolean;
  path?: string;
  element: ReactElement;
}

const AppRoutes: Route[] = [
  {
    index: true,
    element: <HomePage />,
  },
  {
    path: '/about',
    element: <AboutPage />,
  },
];

export default AppRoutes;
