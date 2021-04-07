<template>
  <div class="px-3">
    <h4 class=" mt-4 customTitle">
      جدید ترین اخبار
    </h4>
    <div class="post-card">
      <div class="row">
        <div class="col-12 mt-1">
          <div class="card">
            <div class="card-horizontal">
              <div class="img-square-wrapper">
                <img
                  class=""
                  src="https://cdn.zoomg.ir/2021/2/outriders-game-400x267.jpg"
                  alt=""
                />
                <div class="topicCategories">
                  <a href=""
                    ><label style="cursor:pointer">اخبار بازی</label></a
                  >
                  <a href=""
                    ><label style="cursor:pointer">پلی استیشن</label></a
                  >
                </div>
              </div>
              <div class="card-body">
                <h4 class="card-title">عنوان خبر</h4>

                <div class="d-flex news-info text-muted">
                  <span>
                    <i class="fa fa-user "></i>
                    اصغر صغری زاده
                  </span>

                  <span class="mr-2">
                    <i class="fa fa-calendar "></i>
                    1400/02/05
                  </span>
                  <span class="mr-auto ml-3">
                    <i class="fa fa-comment"></i>
                    12
                  </span>
                </div>
                <hr />
                <p class="card-text">
                  Some quick example text to build on the card title and make up
                  the bulk of the card's content.
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.card-horizontal {
  display: flex;
  flex: 1 1 auto;
}
.news-info {
  font-size: 11px;
}
.card-text {
  font-size: 14px;
  text-align: justify;
}
.card {
  box-shadow: rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px;
}
</style>
