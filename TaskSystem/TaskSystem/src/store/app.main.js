import { subModule } from "./modules/submodule.js"

let storeModel = {
	state: {
		myProp: "value1"
	},
	getters: {
		getMyProp(state) {
			return state.myProp;
		}
	},
	mutations: {
		setMyProp(state, value) {
			state.myProp = value;
		}
	},
	modules: {
		subModule
	}
};

export { storeModel };	