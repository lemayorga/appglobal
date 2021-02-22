// import React from 'react';
// import { Route, Redirect } from 'react-router-dom';
// import  fakeAuth  from '../utils/fakeAuth';
// import Login from '../pages/authentication/Login';
// import routes from './routes';

// const PublicRoute = ({component: Component, restricted, ...rest}) => {
//     return (
//         // restricted = false meaning public route
//         // restricted = true meaning restricted route
//         <Route 
//             {...rest} 
//             render={props => (
//                 fakeAuth.isAuthenticated  && restricted 
//                 ?  <Redirect to={routes.dashboard}  />
//                 : <Component {...props} />
//             )} 
//         />
//     );
// };

