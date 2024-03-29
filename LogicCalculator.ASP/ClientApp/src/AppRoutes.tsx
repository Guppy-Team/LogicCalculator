import React, { ReactElement } from 'react';

import { Home } from './pages/Home';
import { AboutPage } from './pages/AboutPage';

interface Route {
  index?: boolean;
  path?: string;
  element: ReactElement;
}

const AppRoutes: Route[] = [
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
