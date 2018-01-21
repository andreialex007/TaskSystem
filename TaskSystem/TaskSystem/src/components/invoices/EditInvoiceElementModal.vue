<template>
	<div class="edit-invoice-element-category-modal common-modal">
		<div v-show="visible" class="modal-overlay"></div>
		<div v-show="visible" class="modal">
			<div class="modal-dialog" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">
							<span v-show="model.id > 0">Edit</span>
							<span v-show="!model.id">Create</span>
							invoice element <span v-show="!!model.id" class="badge badge-danger">#{{ model.id }}</span>
						</h5>
						<button v-on:click="cancel()" type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body">
						<div v-show="errors.length > 0" class="alert alert-danger" role="alert">
							<strong>Errors found!</strong>
							<ul>
								<li v-for="item in errors">
									{{ item.errorMessage }}
								</li>
							</ul>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Description</label>
								<div class="ttable invoice-element-table">
									<div class="trow">
										<div class="tcell">
											<input type="text" class="form-control" v-model="model.description" placeholder="Description (required)" value="">
										</div>
										<div class="tcell select-2-cell">
											<select2 v-bind:options="commonElementsOptions()" v-bind:value.sync="selectedCommonElementId">
											</select2>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Category (required)</label>
								<select v-model="model.invoiceElementCategoryId" class="form-control">
									<template v-for="category in categories">
										<option v-bind:value="category.id">{{ category.name }}</option>
									</template>
								</select>
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Cost</label>
								<input type="number" class="form-control" v-model="model.cost" placeholder="Cost (required)" value="">
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Qty</label>
								<input type="number" class="form-control" v-model="model.qty" placeholder="Qty (required)" value="">
							</div>
						</div>
						<div class="row form-group">
							<div class="col-md-12">
								<label>Total:</label>&nbsp;&nbsp;&nbsp;<strong>{{ (model.cost || 0) * (model.qty || 0) }} $</strong>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<a v-on:click="ok()" href="javascript:;" class="btn btn-primary">Save</a>
						<a v-on:click="cancel()" href="javascript:;" class="btn btn-secondary" data-dismiss="modal">Cancel</a>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
	import modalBase from "./../common/ModalBase.vue"

	export default {
		extends: modalBase,
		props: {
			data: { type: Object },
			categories: { type: Array },
			commonElements: { type: Array }
		},
		watch: {
			visible(newVal) {
				if (newVal == false)
					this.model = {};
				if (newVal == true)
					this.model = { ...this.data };
			},
			selectedCommonElementId(el) {
				if (!el)
					return "";
				let item = this.commonElements.filter(x => x.id == el)[0];
				let category = this.categories.filter(x => x.id == item.invoiceElementCategoryId)[0];
				this.model.invoiceElementCategoryId = category.id;
				this.model.description = item.description;
				this.model.cost = item.cost;
				this.model.invoiceId = this.$route.params.id;
			}
		},
		data: () => ({
			model: {},
			selectedCommonElementId: 0,
		}),
		methods: {
			commonElementsOptions() {
				return {
					data: this.commonElements.map(x => ({ id: x.id, text: x.description })),
					dropdownAutoWidth: true,
					containerCssClass: "common-elements-select2",
				};
			},
			ok() {
				let component = this;
				component.blockUI({
					message: 'Saving, please wait...'
				});
				this.$http.post(`/invoices/saveelement`,
					this.model)
					.then((x) => {
						component.unblockUI();
						toastr.info("saved", "Success");
						component.okFunc(x.body);
						component.hide();
					}).catch(x => {
						component.unblockUI();
						component.errors = x.body.errors;
					});
			},
			cancel() {
				if (this.cancelFunc)
					this.cancelFunc();
				this.hide();
			}
		}
	}
</script>