import React from "react";
import { Router, Route, Switch  } from 'react-router-dom';
import LayoutMain from '../layouts/LayoutMain';
import RolesPage from '../pages/seguridad/RolesPage';


const AppRouter = () =>( 
    // <Router history={ history }>
    // <Router >
        <Switch>
          {/* <PublicRoute restricted={true} component={Login} path={routes.login} exact /> */}


          <Route>
            <LayoutMain>
              <Switch>

                <Route exact path={["/", "/roles"]} component={RolesPage} />
                {/* <Route exact path="/add" component={AddTutorial} />
                <Route path="/tutorials/:id" component={Tutorial} /> */}

              </Switch>
            </LayoutMain>
          </Route>

        </Switch>
    // </Router> 
)

export default AppRouter;
