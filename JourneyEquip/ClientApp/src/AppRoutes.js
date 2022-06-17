import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from './components/Counter';
import { FetchData } from './components/FetchData';
import { Home as Home2 } from './components/Home';
import Home from './components/pages/home/Home';

const AppRoutes = [
	{
		index: true,
		element: <Home />,
	},
	{
		path: '/counter',
		element: <Counter />,
	},
	{
		path: '/fetch-data',
		requireAuth: true,
		element: <FetchData />,
	},
	...ApiAuthorzationRoutes,
];

export default AppRoutes;
