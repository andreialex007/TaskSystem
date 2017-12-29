import dashboard from "./components/dashboard/DashboardPage.vue"
import login from "./components/login/LoginPage.vue"
import tasks from "./components/tasks/TasksPage.vue"
import users from "./components/users/UsersPage.vue"
import editUser from "./components/users/EditUserPage.vue"
import invoices from "./components/invoices/InvoicesPage.vue"
import customers from "./components/customers/CustomersPage.vue"
import notFound from "./components/not-found/NotFoundPage.vue"
import VueRouter from "vue-router"

window.mainRoutes = [
	{ path: "/", component: dashboard, name: "home", exact: true },
	{ path: "/tasks", component: tasks, name: "tasks", exact: false },
	{ path: "/customers", component: customers, name: "customers", exact: false },
	{ path: "/invoices", component: invoices, name: "invoices", exact: false },
	{ path: "/users", component: users, name: "users", exact: false }
	
];

const router = new VueRouter({
	routes: [
		{ path: "/login", component: login, name: "login" },
		...mainRoutes,
		{ path: "/users/add", component: editUser, name: "addUser", exact: false },
		{ path: "/users/:id", component: editUser, name: "editUser", exact: false },
		{ path: "/customers/add", component: editUser, name: "addCustomer", exact: false },
		{ path: "/customers/:id", component: editUser, name: "editCustomer", exact: false },
		{ path: '*', component: notFound }
	],
	mode: "history"
});


router.beforeEach((to, from, next) => {
	if (window.isUserLoggedIn()) {
		if (to.path.toLowerCase() == "/login") {
			next({ path: '/' });
			return;
		} else {
			next();
			return;
		}
	} else {
		if (to.path.toLowerCase() == "/login") {
			next();
			return;
		} else {
			next({ path: '/login' });
			return;
		}
	}
});


export default router;