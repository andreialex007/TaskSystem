let subModule = {
	namespaced: true,
	state: {
		testValue: "mytestvalue"
	},
	getters: {
		getTestValue(state) {
			return state.testValue;
		}
	},
	mutations: {
		setTestValue(state, value) {
			state.testValue = value;
		}
	}
};

export { subModule };