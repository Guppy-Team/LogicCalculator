import React from 'react';
import { Route, Routes } from 'react-router-dom';

import AppRoutes from './AppRoutes';
import { Layout } from './layouts/Layout';

const App: React.FC = () => {
  return (
    <Layout>
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
      </Routes>
    </Layout>
  );
};

export default App;
