import dashboard from "./components/dashboard/DashboardPage.vue"
import login from "./components/login/LoginPage.vue"
import notFound from "./components/not-found/NotFoundPage.vue"
import VueRouter from "vue-router"

const router = new VueRouter({
	routes: [
		{ path: "", component: dashboard },
		{ path: "/login", component: login },
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