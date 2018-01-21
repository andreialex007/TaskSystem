<template>
	<main-layout>
		<div class="col-lg-12">
			<h1 class="mt-5">
				Invoice Settings
			</h1>

			<hr>

			<h4>Categories</h4>
			<span v-on:click="addCategory()" class="btn btn-success pull-right btn-xs">
				<i class="fa fa-plus"></i>
				Add category
			</span>

			<data-table v-bind:items="categories" v-bind:options="tableOptions">
				<div class="data-table-template">
					<table class="table table-bordered table-striped table-sm">
						<thead class="thead-dark">
							<tr>
								<th>Id</th>
								<th>Name</th>
								<th>Actions</th>
							</tr>
						</thead>
						<tbody>
							<tr v-for="item in categories">
								<th>{{ item.id }}</th>
								<th>{{ item.name }}</th>
								<th>
									<a title="edit" v-on:click="editCategory(item)" class="edit btn btn-primary btn-xs" href="javascript:;">
										<i class="fa fa-edit"></i>
										Edit
									</a>
									<a title="edit" v-on:click="deleteCategory(item)" class="edit btn btn-danger btn-xs" href="javascript:;">
										<i class="fa fa-times"></i>
										Delete
									</a>
								</th>
							</tr>
						</tbody>
					</table>
				</div>
			</data-table>

			<hr />

			<h4>Common Items</h4>
			<span v-on:click="addCommonItem()" class="btn btn-success pull-right btn-xs">
				<i class="fa fa-plus"></i>
				Add common item
			</span>

			<data-table v-bind:items="commonItems" v-bind:options="tableOptions">
				<div class="data-table-template">
					<table class="table table-bordered table-striped table-sm">
						<thead class="thead-dark">
							<tr>
								<th>Id</th>
								<th>Description</th>
								<th>Cost</th>
								<th>Category</th>
								<th>Actions</th>
							</tr>
						</thead>
						<tbody>
							<tr v-for="item in commonItems">
								<th>{{ item.id }}</th>
								<th>{{ item.description }}</th>
								<th>{{ item.cost }}</th>
								<th>{{ item.category }}</th>
								<th>
									<a title="edit" v-on:click="editElement(item)" class="edit btn btn-primary btn-xs" href="javascript:;">
										<i class="fa fa-edit"></i>
										Edit
									</a>
									<a title="edit" v-on:click="deleteElement(item)" class="edit btn btn-danger btn-xs" href="javascript:;">
										<i class="fa fa-times"></i>
										Delete
									</a>
								</th>
							</tr>
						</tbody>
					</table>
				</div>
			</data-table>

		</div>

		<edit-category-modal ref="editCategoryModal" v-bind:data="currentCategory"></edit-category-modal>
		<edit-common-element ref="editCommonElementModal" v-bind:categories="categories" v-bind:data="currentCommonElement"></edit-common-element>
		<confirm-modal ref="confirmModal" title="Are you sure?">
			<span>Are you really want to delete this item?</span>
		</confirm-modal>
	</main-layout>
</template>


<script>
	import mainLayout from "./../layout/MainLayout.vue";
	import dataTable from "./../common/DataTable.vue"
	import confirmModal from "./../common/ConfirmModal.vue"
	import uiBase from "./../common/UiBase.vue"
	import editCategoryModal from "./../invoice-settings/EditInvoiceElementCategoryModal.vue"
	import editCommonElement from "./../invoice-settings/EditCommonInvoiceElementModal.vue"

	export default {
		extends: uiBase,
		components: {
			mainLayout,
			dataTable,
			confirmModal,
			editCategoryModal,
			editCommonElement
		},
		data() {
			return {
				categories: [],
				commonItems: [],
				currentCategory: {},
				currentCommonElement: {},
				tableOptions: {
					"aoColumnDefs": [
						{
							bSortable: false,
							aTargets: [-1]
						}
					],
					order: [
						[0, "asc"]
					]
				}
			};
		},
		watch: {

		},
		mounted() {
			this.load();
		},
		methods: {
			editElement(item) {
				this.currentCommonElement = item;
				this.$refs.editCommonElementModal.show(this.elementSaved);
			},
			addCommonItem() {
				this.currentCommonElement = { id: 0 };
				this.$refs.editCommonElementModal.show(this.elementSaved);
			},
			elementSaved(x) {
				let index = this.commonItems.map(x => x.id).findIndex(u => u == x.id);
				if (index === -1) {
					this.commonItems.push(x);
				} else {
					this.commonItems[index] = x;
				}
				this.$forceUpdate();
			},
			deleteElement(item) {
				let component = this;
				this.$refs.confirmModal.show(function () {
					component.blockUI({
						message: 'Deletion, please wait...'
					});
					component.$http.post("/InvoiceSettings/DeleteCommonInvoiceElement/" + item.id)
						.then(function () {
							component.unblockUI();
							component.load();
						})
				});
			},
			editCategory(item) {
				this.currentCategory = item;
				this.$refs.editCategoryModal.show(this.categorySaved);
			},
			categorySaved(x) {
				let index = this.categories.map(x => x.id).findIndex(u => u == x.id);
				if (index === -1) {
					this.categories.push(x);
				} else {
					this.categories[index] = x;
				}
				this.$forceUpdate();
			},
			deleteCategory(item) {
				let component = this;
				this.$refs.confirmModal.show(function () {
					component.blockUI({
						message: 'Deletion, please wait...'
					});
					component.$http.post("/InvoiceSettings/DeleteInvoiceElementCategory/" + item.id)
						.then(function () {
							component.unblockUI();
							component.load();
						})
				});
			},
			addCategory() {
				this.currentCategory = { id: 0 };
				this.$refs.editCategoryModal.show(this.categorySaved);
			},
			load() {
				this.$http.post(`/invoicesettings/Settings`)
					.then(this.loadCompleted);
			},
			loadCompleted(result) {
				this.commonItems = result.body.elements;
				this.categories = result.body.categories;
			},
			back() {
				this.$router.go(-1);
			}
		}
	}
</script>