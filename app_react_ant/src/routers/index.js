import React from "react";
import { Router, Route, Switch  } from 'react-router-dom';
import LayoutMain from '../layouts/LayoutMain';
import RolesPage from '../pages/seguridad/RolesPage';


const AppRouter = () =>( 
    // <Router history={ history }>
    // <Router >
        <Switch>
          <Route>
            <LayoutMain>
              <Switch>
                <Route exact path={["/", "/roles"]} component={RolesPage} />
              </Switch>
            </LayoutMain>
          </Route>

        </Switch>
    // </Router> 
)

export default AppRouter;
