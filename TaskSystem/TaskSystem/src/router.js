import dashboard from "./components/dashboard/DashboardPage.vue"
import login from "./components/login/LoginPage.vue"
import tasks from "./components/work-tasks/TasksPage.vue"
import users from "./components/users/UsersPage.vue"
import editUser from "./components/users/EditUserPage.vue"
import invoices from "./components/invoices/InvoicesPage.vue"
import editCustomer from "./components/customers/EditCustomerPage.vue"
import editWorkTaskPage from "./components/work-tasks/EditWorkTaskPage.vue"
import customers from "./components/customers/CustomersPage.vue"
import notFound from "./components/not-found/NotFoundPage.vue"
import VueRouter from "vue-router"

window.mainRoutes = [
	{ path: "/", component: dashboard, name: "home", exact: true },
	{ path: "/worktasks", component: tasks, name: "worktasks", exact: false },
	{ path: "/invoices", component: invoices, name: "invoices", exact: false },
	{ path: "/customers", component: customers, name: "customers", exact: false },
	{ path: "/users", component: users, name: "users", exact: false }
	
];

const router = new VueRouter({
	routes: [
		{ path: "/login", component: login, name: "login" },
		...mainRoutes,
		{ path: "/users/add", component: editUser, name: "addUser", exact: false },
		{ path: "/users/:id", component: editUser, name: "editUser", exact: false },
		{ path: "/customers/add", component: editCustomer, name: "addCustomer", exact: false },
		{ path: "/customers/:id", component: editCustomer, name: "editCustomer", exact: false },
		{ path: "/worktasks/add", component: editWorkTaskPage, name: "addWorkTask", exact: false },
		{ path: "/worktasks/:id", component: editWorkTaskPage, name: "editWorkTask", exact: false },
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